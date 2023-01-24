using System;
using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using Mirror;
using Mirror.Discovery;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private InputHandler inputHandler;

    public ProCamera2D camera;

    public PlayerState state;
    public Drone drone;
    public Crew crew;

    private void Awake()
    {
        camera = Camera.main.GetComponent<ProCamera2D>();
    }

    private void Start()
    {
        state.EnableUser();
        state.SetOnBoard();
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            inputHandler.Handle();
        }
    }
}
