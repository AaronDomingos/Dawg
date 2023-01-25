using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

/* This class provides an interface to transfer data between the main menu and the player data manager upon player spawn.
 * Thus, it should always be attached to the menu player object. */
public class MenuDataController : NetworkBehaviour
{
    private TMPro.TMP_InputField playerNameInputField;
    PlayerData playerData;

    public override void OnStartLocalPlayer()
    {
        CmdUpdatePlayerData(playerData.SaveToJsonString());
    }

    [Command]
    private void CmdUpdatePlayerData(string jsonPlayerData)
    {
        // Send player data from input field(s) to the player data manager
        int connId = gameObject.GetComponent<NetworkIdentity>().connectionToClient.connectionId;
        PlayerDataManager.singleton.CmdUpdatePlayerData(connId, jsonPlayerData);
    }

    private void Awake()
    {
        playerNameInputField = FindObjectOfType<TMPro.TMP_InputField>();
        playerData = new PlayerData(playerNameInputField.text, false);
    }
}
