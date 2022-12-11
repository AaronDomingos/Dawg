using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;

public class InteractionComponent : NetworkBehaviour
{
    [SerializeField] public float Range { get; private set; } = 5f;

    [SerializeField] private bool LimitInterations = true;
    [SerializeField] private Int16 InteractionsLimit = 1;
    private Int16 CurrentInteractions = 0;

    public UnityEvent OnFailedInteraction;
    public UnityEvent OnSuccessfulInteraction;
    
    public void TryInteract() 
    {
        if (LimitInterations && CurrentInteractions >= InteractionsLimit)
        {
            FailedInteraction();
            return;
        }
        SuccessfulInteraction();
    }
    
    private void FailedInteraction()
    {
        Debug.Log("Interaction Failed");
        OnFailedInteraction.Invoke();
    }
    
    private void SuccessfulInteraction()
    {
        Debug.Log("Interaction Successful");
        OnSuccessfulInteraction.Invoke();
    }
}
