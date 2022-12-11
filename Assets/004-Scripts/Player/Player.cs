using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private InputHandler inputHandler;

    public PlayerState state;
    public Character character;
    public Drone drone;

    public GameObject interactablePrefab;
    public GameObject interactableInstance;

    private void Start()
    {
        state.EnableUser();
        state.SetOnboard();
        
        //interactable = GameObject.Find("InteractableObject");
    }

    private void Update()
    {
        if (IsOwner)
        {
            inputHandler.Handle();
        }
    }
}
