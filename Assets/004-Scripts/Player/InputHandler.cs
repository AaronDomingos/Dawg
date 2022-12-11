using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Netcode;
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
        HandleTestInputs();
        
        if (player.state.isUserActive)
        {
            HandleUserInputs();   
        }

        if (player.state.isCharacterActive)
        {
            HandleCharacterInputs();
        }

        else if (player.state.isDroneActive)
        {
            HandleDroneInputs();
        }
    }

    private void HandleUserInputs()
    {
        if (userInput.UserActions.Escape.WasReleasedThisFrame())
        {
            Debug.Log("Exit Program");
        }
    }

    private void HandleCharacterInputs()
    {
        player.character.movement.MoveOnBoard(
            userInput.PlayerActions.Move.ReadValue<Vector2>());
    }

    private void HandleDroneInputs()
    {
        player.drone.movement.MoveOffBoard(
            userInput.PlayerActions.Move.ReadValue<Vector2>());
    }

    private void HandleTestInputs()
    {
        if (userInput.AdminTesting.TogglePlayer.WasReleasedThisFrame())
        {
            if (player.state.isCharacterActive)
            {
                player.state.SetOffBoard();
            }

            else if (player.state.isDroneActive)
            {
                player.state.SetOnboard();
            }
        }

        if (userInput.AdminTesting.SpawnObject.WasReleasedThisFrame())
        {
            GameObject objectRef = Instantiate(
                player.interactablePrefab, 
                player.character.transform.position,
                quaternion.identity);
            
            objectRef.GetComponent<NetworkObject>().Spawn();
            player.interactableInstance = objectRef;
        }
        
        if (userInput.PlayerActions.Interact.WasReleasedThisFrame())
        {
            player.interactableInstance.GetComponent<InteractionComponent>().TryInteract();
        }
    }
}
