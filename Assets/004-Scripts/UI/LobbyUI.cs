using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    // UI elements
    [SerializeField] private Button readyBtn;
    [SerializeField] private Button leaveBtn;

    [SerializeField] private int maxPlayers;

    // Keep track of all the lobby player slots in our UI
    private List<LobbyPlayerSlot> lobbyPlayerSlots = new List<LobbyPlayerSlot>();

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the player slots list with all lobby player slots in the scene
        foreach(LobbyPlayerSlot lobbyPlayerSlot in GameObject.FindObjectsOfType<LobbyPlayerSlot>())
        {
            lobbyPlayerSlots.Add(lobbyPlayerSlot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
