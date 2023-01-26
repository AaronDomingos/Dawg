using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    [SerializeField] private DroneInputHandler input;
    
    public IdDetector interactableDetector;
    public Interactable currentInteraction;
    public DroneMovement droneMovement;

    private void Update()
    {
        input.Handle();
    }
    
    public void ApplyThrust(Vector3 direction)
    {
        droneMovement.SetDirection(direction);
    }
}
