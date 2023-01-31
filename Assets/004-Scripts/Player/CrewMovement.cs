using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrewMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 500f;
    
    public bool CanMove = true;
    public Vector3 Direction = Vector3.zero;

    private void FixedUpdate()
    {
        HandleMovement();
    }

    public void SetCanMove(bool canMove)
    {
        CanMove = canMove;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }
    
    private void HandleMovement()
    {
        if (CanMove)
        {
            transform.position += Direction * Speed * Time.fixedDeltaTime;
        }
    }
    
    public void SetCrewMovement(bool canMove)
    {
        CanMove = canMove;
    }
}
