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
        
        if (player.state.isUserActive)
        {
            HandleUserInputs();   
        }

        if (player.state.isCrewActive)
        {
            HandleCrewInputs();
        }

        else if (player.state.isDroneActive)
        {
            HandleDroneInputs();
        }
    }

    private void HandleUserInputs()
    {
        if (userInput.User.Quit.WasReleasedThisFrame())
        {
            Debug.Log("Exit Program");
        }
    }

    private void HandleCrewInputs()
    {
        player.crew.movement.SetDirection(
            userInput.Crew.Walk.ReadValue<Vector2>());
    }

    private void HandleDroneInputs()
    {
        player.drone.HandleThrust(
            userInput.Drone.Thrust.ReadValue<Vector2>());
    }

    private void HandleAdminInputs()
    {
        if (userInput.Admin.Toggle.WasReleasedThisFrame())
        {
            if (player.state.isCrewActive)
            {
                player.state.SetOffBoard();
            }

            else if (player.state.isDroneActive)
            {
                player.state.SetOnboard();
            }
        }
    }
}
