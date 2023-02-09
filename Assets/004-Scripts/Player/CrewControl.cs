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

    public Animator animator;

    private void Update()
    {
        input.Handle();
    }
    
    public void ApplyWalk(Vector3 direction)
    {
        crewMovement.SetDirection(direction);
        if (direction == Vector3.zero || crewMovement.CanMove == false)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    public void SetColor(Color newColor)
    {
        CrewColor = newColor;
        sprite.color = newColor;
    }
}
