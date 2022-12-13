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
        player.character.movement.SetOnBoard(
            userInput.PlayerActions.Move.ReadValue<Vector2>());
    }

    private void HandleDroneInputs()
    {
        player.drone.movement.SetOffBoard(
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
            SpawnObject();
        }
        
        if (userInput.PlayerActions.Interact.WasReleasedThisFrame())
        {
            GameObject obj = GameObject.Find("TestObjectSpawner").GetComponent<TestObjectSpawner>().objectInstance;
            obj.GetComponent<InteractionComponent>().TryInteract();
        }

        if (userInput.AdminTesting.StartSpawner.WasReleasedThisFrame())
        {
            GameObject.Find("MateriumSpawner").GetComponent<MateriumSpawner>().StartSpawning();
            Debug.Log("Starting to Spawn");
        }
    }

    private void SpawnObject()
    {
        GameObject.Find("TestObjectSpawner").GetComponent<TestObjectSpawner>().SpawnObjectServerRpc(player.character.transform.position);
    }
}
