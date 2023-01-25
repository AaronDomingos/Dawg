using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using Mirror;

public class LobbyPlayerSlot : NetworkBehaviour
{
    // UI elements comprising each player slot
    [SerializeField] private TMP_Text playerNameTxt;
    [SerializeField] private Toggle readyToggle;

    // Lobby player data attached to the slot
    // Value is serialized in JSON so it can be transmitted to the server
    /* TO-DO: enable custom serialization of PlayerData over the network */
    [SyncVar]
    public PlayerData playerData;

    // Initial (placeholder) value of player name text
    private string playerNamePlaceholder;

    [SyncVar]
    public bool isOpen = true;

    [Command(requiresAuthority = false)]
    public void CmdUpdatePlayerData(PlayerData value)
    {
        playerData = value;
        RpcUpdateDataDisplay(value);
        isOpen = false;
    }

    [Command(requiresAuthority = false)]
    private void CmdSetOpenStatus(bool status)
    {
        isOpen = status;
    }

    [ClientRpc]
    void RpcUpdateDataDisplay(PlayerData playerData)
    {
        UpdateDataDisplay(playerData);
    }

    void UpdateDataDisplay(PlayerData playerData)
    {
        playerNameTxt.text = playerData.PlayerName;
        readyToggle.isOn = playerData.IsReady;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerNamePlaceholder = playerNameTxt.text;
    }

    public void Clear()
    {
        // netId 9000 should never be reached...
        PlayerData emptyData = new PlayerData(9000, playerNamePlaceholder, false);
        // Reset struct to default value
        CmdUpdatePlayerData(emptyData);
        CmdSetOpenStatus(true);
    }

    // When a new client connects...
    public override void OnStartClient()
    {
        {
            // If slot is used by another player...
            if (!isOpen)
            {
                // Update its displayed data to reflect that...
                UpdateDataDisplay(playerData);
            }
        }
    }
}
