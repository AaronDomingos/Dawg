using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float MinimumSpeed = .01f;
    [SerializeField] private float MaximumSpeed = .5f;
    [SerializeField] private float AccelerationRate = .05f;
    [SerializeField] private float DecelerationRate = .99f;

    public MovementType movementType = MovementType.OnBoard;
    public bool shouldRotate = true;
    private float RotateSpeed = 300f;
    
    private Vector3 Direction = Vector3.zero;
    private Vector3 Momentum = Vector3.zero;
    private float CurrentSpeed = 1f;

    private GameObject target;

    public enum MovementType
    {
        OnBoard,
        OffBoard,
        Attract,
        Repel
    }

    private void OnDisable()
    {
        ResetMovement();
    }

    private void FixedUpdate()
    {
        switch (movementType)
        {
            case MovementType.OffBoard:
                HandleDynamicMovement();
                break;
            case MovementType.OnBoard:
                HandleStaticMovement();
                break;
            case MovementType.Attract:
                Direction = target.transform.position - transform.position;
                HandleDynamicMovement();
                break;
            case MovementType.Repel:
                Direction = transform.position - target.transform.position;
                HandleDynamicMovement();
                break;
        }

        if (shouldRotate)
        {
            Quaternion toRotate = Quaternion.LookRotation(
                Vector3.forward, Momentum);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, toRotate, RotateSpeed * Time.deltaTime);
        }
    }

    private void HandleDynamicMovement()
    {
        Momentum = Vector3.ClampMagnitude(
            Momentum + (Direction * AccelerationRate), MaximumSpeed);

        transform.position += Momentum * Time.fixedDeltaTime;
        if (Momentum != Vector3.zero)
        {
            transform.position += Momentum;
            Momentum *= DecelerationRate;
            if (Momentum.x < MinimumSpeed && Momentum.x > -MinimumSpeed &&
                Momentum.y < MinimumSpeed && Momentum.y > -MinimumSpeed)
            {
                Momentum = Vector3.zero;
            }
        }
    }

    private void HandleStaticMovement()
    {
        transform.position += Direction * MaximumSpeed * Time.fixedDeltaTime;
    }
    
    public void ResetMovement()
    {
        Direction = Vector3.zero;
        Momentum = Vector3.zero;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    public void SetAttraction(GameObject newTarget)
    {
        movementType = MovementType.Attract;
        target = newTarget;
    }

    public void SetRepulsion(GameObject newTarget)
    {
        movementType = MovementType.Repel;
        target = newTarget;
    }
}
