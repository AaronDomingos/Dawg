using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public IdDetector Detector;
    [SerializeField] private UnityEvent InteractionEvent;
    [SerializeField] private UnityEvent CancelationEvent;

    [SerializeField] private int RequiredNumberOfInteractors = 1;
    [SerializeField] private int AllowableNumberOfInteractions = 1;
    public List<GameObject> ActiveInteractors = new List<GameObject>();
    public InteractableState CurrentState = InteractableState.Default;

    private GameObject EligibleInteractor = null;
    
    public enum InteractableState
    {
        Default = 0,
        ActiveCanInteract = 1,
        ActiveIsInteracting = 2
    }
    
    private void FixedUpdate()
    {
        EligibleInteractor = TryFindActiveInteractor();
        CurrentState = HandleInteractableState();
    }
    
    private GameObject TryFindActiveInteractor()
    {
        if (Detector.DetectedObjects.Count > 0)
        {
            foreach (GameObject interactor in Detector.DetectedObjects)
            {
                // Check for active playable by active inputHandler
                if (interactor.TryGetComponent(out InputHandler inputHandler) &&
                    inputHandler != null && inputHandler.enabled)
                {
                    return interactor;
                }
            }
        }
        return null;
    }

    private InteractableState HandleInteractableState()
    {
        if (EligibleInteractor != null)
        {
            if (ActiveInteractors.Contains(EligibleInteractor))
            {
                return InteractableState.ActiveIsInteracting;
            }
            return InteractableState.ActiveCanInteract;
        }
        return InteractableState.Default;
    }

    public bool canInteract()
    {
        if (ActivePlayerInZone() && MinimumRequiredInteractors() && AllowableInteractionAvailable())
        {
            return true;
        }
        Debug.Log("Interaction Failed");
        return false;
    }

    private bool ActivePlayerInZone()
    {
        if (Detector.DetectedObjects.Contains(EligibleInteractor))
        {
            return true;
        }
        //Debug.Log("Active playable is not in zone");
        return false;
    }
    
    private bool MinimumRequiredInteractors()
    {
        if (Detector.DetectedObjects.Count >= RequiredNumberOfInteractors)
        {
            return true;
        }
        Debug.Log("Not enough interactors in zone");
        return false;
    }

    private bool AllowableInteractionAvailable()
    {
        if (ActiveInteractors.Count < AllowableNumberOfInteractions)
        {
            return true;
        }
        Debug.Log("Too many active interactions");
        return false;
    }

    public void Interact(GameObject interactor)
    {
        if (canInteract())
        {
            Debug.Log("Invoking Interaction");
            ActiveInteractors.Add(interactor);
            if (InteractionEvent != null)
            {
                InteractionEvent.Invoke();
                return;
            }
            Debug.Log("No Interaction Event");
        }
    }

    public void Cancel(GameObject interactor)
    {
        if (ActiveInteractors.Contains(interactor))
        {
            Debug.Log("Cancelling interaction"); 
            ActiveInteractors.Remove(interactor);
            if (CancelationEvent != null)
            {
                CancelationEvent.Invoke();
                return;
            }
            Debug.Log("No Cancellation Event");
        }
    }
}
