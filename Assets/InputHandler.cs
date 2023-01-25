using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private UserInput userInput;
    private Player player;

    #region Awake, Enable, Disable
    private void Awake()
    {
        userInput = new UserInput();
        player = transform.GetComponent<Player>();
    }

    private void OnEnable()
    {
        userInput.Enable();
    }

    private void OnDisable()
    {
        userInput.Disable();
    }
    #endregion
    
    public void Handle()
    {
        HandleAdminInputs();
    }

    private void HandleUserInputs()
    {
        if (userInput.User.Toggle.WasReleasedThisFrame())
        {
            
        }
    }

    private void HandleCrewInputs()
    {
        
    }

    private void HandleDroneInputs()
    {
        
    }

    private void HandleAdminInputs()
    {
        
    }
}
