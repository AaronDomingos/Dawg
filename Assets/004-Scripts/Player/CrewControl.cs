using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewControl : MonoBehaviour
{
    [SerializeField] private CrewInputHandler input;

    public Color CrewColor = Color.white;
    public SpriteRenderer sprite;
    
    public IdDetector interactableDetector;
    public Interactable currentInteraction;
    public CrewMovement crewMovement;

    private void Update()
    {
        input.Handle();
    }
    
    public void ApplyWalk(Vector3 direction)
    {
        crewMovement.SetDirection(direction);
    }

    public void SetColor(Color newColor)
    {
        CrewColor = newColor;
        sprite.color = newColor;
    }
}
