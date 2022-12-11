using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public Vector3 Direction = Vector3.zero;
    public Vector3 Momentum = Vector3.zero;

    private float DecelerationRate = .99f;
    private float MinimumSpeed = .01f;

    private float Speed = .01f;


    private void Update()
    {
        //transform.position += Momentum;

        if (Momentum != Vector3.zero)
        {
            transform.position += Momentum;
            HandleMomentum();
        }
    }


    public void MoveOnBoard(Vector3 direction)
    {
        transform.position += direction * Speed;
    }


    public void MoveOffBoard(Vector3 direction)
    {
        transform.position += direction * Speed;
    }

    private void HandleMomentum()
    {
        Momentum *= DecelerationRate;
        if (Momentum.x < MinimumSpeed && Momentum.y < MinimumSpeed)
        {
            Momentum = Vector3.zero;
        }
    }
}
