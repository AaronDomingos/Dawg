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
    private PlayerData playerData;

    // Initial (placeholder) value of player name text
    private string playerNamePlaceholder;

    // Getter(s) and setter(s)
    public PlayerData LobbyPlayerData { get => playerData;
        set
        {
            playerData = value;
            UpdateView(value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerNamePlaceholder = playerNameTxt.text;
    }

    void UpdateView(PlayerData playerData)
    {
        playerNameTxt.text = playerData.Name;
        readyToggle.isOn = playerData.IsReady;
    }

    void ClearSlot()
    {
        // Reset struct to default value
        playerData = new PlayerData();

        playerNameTxt.text = playerNamePlaceholder;
        readyToggle.isOn = false;
    }

    bool IsOpen()
    {
        // If struct is currently set to its default value...
        if(EqualityComparer<PlayerData>.Default.Equals(playerData, default(PlayerData)))
        {
            // ... this slot is open!
            return true;
        }

        // If not, it's closed!
        return false;
    }
}
