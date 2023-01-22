using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;

    public PlayerState state;
    public Drone drone;
    public Crew crew;

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
