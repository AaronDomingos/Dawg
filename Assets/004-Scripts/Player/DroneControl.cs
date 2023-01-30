using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    [SerializeField] private DroneInputHandler input;

    public GameObject Pilot;
    
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

    public virtual void TryPrimaryWeapon()
    {
        Debug.Log("Trying to use primary weapon");
    }

    public virtual void TrySpecialAbility()
    {
        Debug.Log("Trying special ability");
    }

    public virtual void ActivateAutoPilot()
    {
        Debug.Log("Activating auto pilot");
    }

    public virtual void DeactivateAutoPilot()
    {
        Debug.Log("Deactivating auto pilot");
    }
}
