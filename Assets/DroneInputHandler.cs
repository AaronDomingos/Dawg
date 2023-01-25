using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneInputHandler : InputHandler
{
    public override string Name 
    { get { return "Drone"; } }
    
    private UserInput userInput;
    [SerializeField] private DroneControl drone;

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
        drone.ApplyThrust(userInput.Drone.Thrust.ReadValue<Vector2>());
    }
}
