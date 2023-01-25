using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : InputHandler
{
    private UserInput userInput;
    [SerializeField] private Player player;

    private void Awake()
    {
        userInput = new UserInput();
    }
    private void OnEnable()
    {
        userInput.Enable();
    }

    private void OnDisable()
    {
        userInput.Disable();
    }
    
    public void Handle()
    {
        #region SwitchActivePlayer
        if (userInput.User.Toggle.WasReleasedThisFrame())
        {
            if (userInput.User.Shift.IsPressed())
            {
                player.LastPlayable();
            }
            player.NextPlayable();
        }
        if (userInput.User.Index1.WasReleasedThisFrame()) {player.GoToPlayableIndex(0);}
        if (userInput.User.Index2.WasReleasedThisFrame()) {player.GoToPlayableIndex(1);}
        if (userInput.User.Index3.WasReleasedThisFrame()) {player.GoToPlayableIndex(2);}
        if (userInput.User.Index4.WasReleasedThisFrame()) {player.GoToPlayableIndex(3);}
        if (userInput.User.Index5.WasReleasedThisFrame()) {player.GoToPlayableIndex(4);}
        if (userInput.User.Index6.WasReleasedThisFrame()) {player.GoToPlayableIndex(5);}
        if (userInput.User.Index7.WasReleasedThisFrame()) {player.GoToPlayableIndex(6);}
        if (userInput.User.Index8.WasReleasedThisFrame()) {player.GoToPlayableIndex(7);}
        if (userInput.User.Index9.WasReleasedThisFrame()) {player.GoToPlayableIndex(8);}
        if (userInput.User.Index0.WasReleasedThisFrame()) {player.GoToPlayableIndex(9);}
        #endregion
    }
}
