using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using UnityEngine.SceneManagement;

public class LobbyUI : MonoBehaviour
{
    // UI elements
    [SerializeField] private TMPro.TMP_InputField playerNameInput;

    [SerializeField] private string menuSceneName = "MainMenu";

    // Keep track of all the lobby player slots in our UI
    [SerializeField]private List<LobbyPlayerSlot> lobbyPlayerSlots = new List<LobbyPlayerSlot>();

    public void OnClickUpdate()
    {
        uint netId = NetworkClient.localPlayer.gameObject.GetComponent<NetworkIdentity>().netId;

        // Package new player data
        PlayerData playerData = new PlayerData(netId, playerNameInput.text, false);
        // Update player data
        PlayerDataManager.singleton.CmdUpdatePlayerData(netId, playerData);

        // Display player data
        LobbyPlayerSlot playerSlot = FindOpenPlayerSlot();
        if (playerSlot != null)
        {
            playerSlot.CmdUpdatePlayerData(playerData);
        }
    }

    private LobbyPlayerSlot FindLobbyPlayerSlotFromNetId(uint netId)
    {
        foreach (LobbyPlayerSlot lobbyPlayerSlot in lobbyPlayerSlots)
        {
            if(lobbyPlayerSlot.playerData.NetId == netId)
            {
                return lobbyPlayerSlot;
            }
        }

        return null;
    }

    /* Start and stop host must be delayed. If they're called immediately after updating the UI, the UI becomes unusable. */
    private IEnumerator DelayedStopHost()
    {
        yield return new WaitForSeconds(1.0f);
        NetworkManager.singleton.StopHost();
    }

    private IEnumerator DelayedStopClient()
    {
        yield return new WaitForSeconds(1.0f);
        NetworkManager.singleton.StopHost();
    }

    public void OnClickLeave()
    {
        // netId CANNOT be set in start. The only way I can get this to work is if I set it as soon as it's needed!
        uint netId = NetworkClient.localPlayer.gameObject.GetComponent<NetworkIdentity>().netId;
        LobbyPlayerSlot slot = FindLobbyPlayerSlotFromNetId(netId);

        if(slot != null)
        {
            slot.Clear();
        }

        // If client is host...
        if(NetworkClient.localPlayer.gameObject.GetComponent<NetworkIdentity>().isServer)
        {
            StartCoroutine(DelayedStopHost());
        } else
        {
            StartCoroutine(DelayedStopClient());
        }
    }

    private LobbyPlayerSlot FindOpenPlayerSlot()
    {
        // netId CANNOT be set in start. The only way I can get this to work is if I set it as soon as it's needed!
        uint netId = NetworkClient.localPlayer.gameObject.GetComponent<NetworkIdentity>().netId;

        // If there's a player slot already used by the local player, find it
        LobbyPlayerSlot usedSlot = FindLobbyPlayerSlotFromNetId(netId);

        // If there is a slot in use by this player...
        if (usedSlot != null)
        {
            return usedSlot;
        }

        foreach (LobbyPlayerSlot lobbyPlayerSlot in lobbyPlayerSlots)
        {
            // Or, if a slot is open
            if (lobbyPlayerSlot.isOpen)
            {
                return lobbyPlayerSlot;
            }
        }

        return null;
    }
}
