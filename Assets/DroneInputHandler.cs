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
        
        if (userInput.Crew.Interact.WasReleasedThisFrame())
        {
            TryInteraction();
        }

        if (userInput.Crew.Cancel.WasReleasedThisFrame())
        {
            CancelInteraction();
        }
    }
    
    
    private void TryInteraction()
    {
        if (drone.interactableDetector.DetectedObjects.Count == 0)
        {
            Debug.Log("No interactable objects detected.");
            return;
        }
            
        List<GameObject> interactables = Proximity.OrderGameObjectsByProximity(
            drone.gameObject, drone.interactableDetector.DetectedObjects);
            
        foreach (GameObject obj in interactables)
        {
            if (obj.TryGetComponent(out Interactable interactable) &&
                interactable.Detector.DetectedObjects.Contains(gameObject))
            {
                if (interactable.canInteract())
                {
                    drone.currentInteraction = interactable;
                    interactable.Interact(gameObject);
                    return;
                }
            }
        }
        Debug.Log("Interactable objects detected, but failed to interact.");
    }

    private void CancelInteraction()
    {
        if (drone.currentInteraction != null &&
            drone.currentInteraction.ActiveInteractors.Contains(drone.gameObject))
        {
            drone.currentInteraction.Cancel(gameObject);
            drone.currentInteraction = null;
            return;
        }
        Debug.Log("Failed to cancel interaction");
    }
}
