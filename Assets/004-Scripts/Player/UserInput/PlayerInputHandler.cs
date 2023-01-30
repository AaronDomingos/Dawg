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
        #region SwitchActivePlayer
        if (userInput.User.Toggle.WasReleasedThisFrame() && GameManager.Player.CanToggle)
        {
            if (userInput.User.Shift.IsPressed())
            {
                GameManager.Player.LastPlayable();
            }

            GameManager.Player.NextPlayable();
        }
        if (userInput.User.Index1.WasReleasedThisFrame() && 
            GameManager.Player.CanToggle) {GameManager.Player.GoToPlayableIndex(0);}
        if (userInput.User.Index2.WasReleasedThisFrame() && 
            GameManager.Player.CanToggle) {GameManager.Player.GoToPlayableIndex(1);}
        if (userInput.User.Index3.WasReleasedThisFrame() && 
            GameManager.Player.CanToggle) {GameManager.Player.GoToPlayableIndex(2);}
        if (userInput.User.Index4.WasReleasedThisFrame() && 
            GameManager.Player.CanToggle) {GameManager.Player.GoToPlayableIndex(3);}
        if (userInput.User.Index5.WasReleasedThisFrame() && 
            GameManager.Player.CanToggle) {GameManager.Player.GoToPlayableIndex(4);}
        if (userInput.User.Index6.WasReleasedThisFrame() && 
            GameManager.Player.CanToggle) {GameManager.Player.GoToPlayableIndex(5);}
        if (userInput.User.Index7.WasReleasedThisFrame() && 
            GameManager.Player.CanToggle) {GameManager.Player.GoToPlayableIndex(6);}
        if (userInput.User.Index8.WasReleasedThisFrame() && 
            GameManager.Player.CanToggle) {GameManager.Player.GoToPlayableIndex(7);}
        if (userInput.User.Index9.WasReleasedThisFrame() && 
            GameManager.Player.CanToggle) {GameManager.Player.GoToPlayableIndex(8);}
        if (userInput.User.Index0.WasReleasedThisFrame() && 
            GameManager.Player.CanToggle) {GameManager.Player.GoToPlayableIndex(9);}
        #endregion
    }
}
