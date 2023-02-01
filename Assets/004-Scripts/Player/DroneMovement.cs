using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    [SerializeField] private float RotateSpeed = 300f;
    [SerializeField] private float MinimumSpeed = .001f;
    [SerializeField] private float MaximumSpeed = .1f;
    [SerializeField] private float AccelerationRate = .005f;
    [SerializeField] private float DecelerationRate = .99f;
    
    private Vector3 Direction = Vector3.zero;
    private Vector3 Momentum = Vector3.zero;
    private Vector3 RightStick = Vector3.zero;

    public List<Transform> ThingsToRotate = new List<Transform>();

    private bool canMove = true;

    private void FixedUpdate()
    {
        HandleMomentum();
        DefaultRotation();
        RightStickRotation();
    }

    public void SetCanMove(bool value)
    {
        if (value == false)
        {
            Direction = Vector3.zero;
            Momentum = Vector3.zero;
            canMove = false;
            return;
        }
        canMove = true;
    }

    private void HandleMomentum()
    {
        if (canMove)
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
    }

    private void DefaultRotation()
    {
        if (Direction != Vector3.zero && Momentum != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(
                Vector3.forward, Momentum);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, toRotate, RotateSpeed * Time.fixedDeltaTime);
        }
    }

    private void RightStickRotation()
    {
        // Quaternion toRotate = Quaternion.LookRotation(
        //     Vector3.forward, RightStick);
        // transform.rotation = Quaternion.RotateTowards(
        //     transform.rotation, toRotate, RotateSpeed * Time.fixedDeltaTime);

        foreach (Transform obj in ThingsToRotate)
        {
            Quaternion toRotate = Quaternion.LookRotation(
                Vector3.zero, RightStick);
            obj.rotation = Quaternion.RotateTowards(
                transform.rotation, toRotate, RotateSpeed * Time.fixedDeltaTime);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction.normalized;
    }

    public void SetMomentum(Vector3 direction, float power)
    {
        Momentum = direction * power;
    }

    public void SetRotation(Vector3 direction)
    {
        RightStick = direction;
    }
}
