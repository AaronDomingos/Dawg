using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    [SerializeField] private DroneInputHandler input;

    public Color DroneColor = Color.white;
    public SpriteRenderer sprite;
        
    public IdDetector interactableDetector;
    public Interactable currentInteraction;
    public DroneMovement droneMovement;

    private void Update()
    {
        input.Handle();
    }

    public void SetDroneColor(Color newColor)
    {
        DroneColor = newColor;
        sprite.color = newColor;
    }

    public void ApplyThrust(Vector3 direction)
    {
        droneMovement.SetDirection(direction);
    }

    public void SetRotationTarget(Vector3 direction)
    {
        droneMovement.SetRotation(direction);
        if (direction != null && direction != Vector3.zero)
        {
            TryPrimaryWeapon();
        }
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

    public void OnStatusDestroy()
    {
        GameManager.Player.RemovePlayable(gameObject);
        Destroy(gameObject);
    }
}
