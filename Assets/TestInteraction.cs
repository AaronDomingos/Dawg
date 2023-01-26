using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TestInteraction : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Interactable interactable;

    private Color Default = Color.white;
    private Color Eligible = Color.green;
    private Color Interacting = Color.red;

    private void Update()
    {
        switch (interactable.CurrentState)
        {
            case Interactable.InteractableState.Default:
                sprite.color = Default;
                break;
            case Interactable.InteractableState.ActiveCanInteract:
                sprite.color = Eligible;
                break;
            case Interactable.InteractableState.ActiveIsInteracting:
                sprite.color = Interacting;
                break;
        }
    }

    public void OnInteract()
    {
        Eligible = Color.blue;
    }

    public void OnCancelled()
    {
        Eligible = Color.green;
    }
}
