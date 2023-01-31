using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : InputHandler
{
    private UserInput userInput;

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
        if (userInput.User.NextPlayable.WasReleasedThisFrame() && GameManager.Player.CanToggle)
        {
            GameManager.Player.NextPlayable();
        }

        if (userInput.User.LastPlayable.WasPressedThisFrame() && GameManager.Player.CanToggle)
        {
            GameManager.Player.LastPlayable();
        }
    }
}
