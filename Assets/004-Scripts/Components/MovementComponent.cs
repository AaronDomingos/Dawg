using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MovementComponent : MonoBehaviour
{
    public Vector3 Direction = Vector3.zero;
    public Vector3 Momentum = Vector3.zero;

    private float AccelerationRate = .05f;
    private float DecelerationRate = .99f;
    private float MinimumSpeed = .01f;
    private float MaximumSpeed = .5f;

    private float Speed = 1f;


    private void FixedUpdate()
    {
        transform.position += Direction * Speed * Time.fixedDeltaTime;

        if (Momentum != Vector3.zero)
        {
            transform.position += Momentum;
            HandleMomentum();
        }
    }

    public void SetOnBoard(Vector3 direction)
    {
        Direction = direction;
    }
    
    public void SetOffBoard(Vector3 direction)
    {
        Direction = direction * 5f;
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
