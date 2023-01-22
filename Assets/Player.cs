using System;
using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;

public class Player : MonoBehaviour
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
        state.SetOnboard();
    }

    private void Update()
    {
        inputHandler.Handle();
    }
}
