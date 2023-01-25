using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    public Color Default = Color.white;
    public UnityEvent Interaction;


    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision Detected");
        sprite.color = Color.green;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Collision Lost");
        sprite.color = Default;
    }

    public void Interact()
    {
        InteractionTest();
    }
    
    private void InteractionTest()
    {
        sprite.color = Color.red;
    }
}
