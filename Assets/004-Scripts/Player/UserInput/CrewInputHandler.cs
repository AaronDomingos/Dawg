using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrewInputHandler : InputHandler
{
    public override string Name 
    { get { return "Crew"; } }
    
    private UserInput userInput;
    [SerializeField] private CrewControl crew;

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
        crew.ApplyWalk(userInput.Crew.Walk.ReadValue<Vector2>());

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
        if (crew.interactableDetector.DetectedObjects.Count == 0)
        {
            Debug.Log("No interactable objects detected.");
            return;
        }
            
        List<GameObject> interactables = Proximity.OrderGameObjectsByProximity(
            crew.gameObject, crew.interactableDetector.DetectedObjects);
            
        foreach (GameObject obj in interactables)
        {
            if (obj.TryGetComponent(out Interactable interactable) &&
                interactable.Detector.DetectedObjects.Contains(gameObject))
            {
                if (interactable.canInteract())
                {
                    Debug.Log(interactable);
                    crew.currentInteraction = interactable;
                    interactable.Interact(gameObject);
                    return;
                }
            }
        }
        Debug.Log("Interactable objects detected, but failed to interact.");
    }

    private void CancelInteraction()
    {
        if (crew.currentInteraction != null &&
            crew.currentInteraction.ActiveInteractors.Contains(crew.gameObject))
        {
            crew.currentInteraction.Cancel(gameObject);
            crew.currentInteraction = null;
            return;
        }
        Debug.Log("Failed to cancel interaction");
    }
}
