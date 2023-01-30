using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField] private float RotateSpeed = 300f;
    [SerializeField] private float MinimumSpeed = .001f;
    public float MaximumSpeed = .1f;
    [SerializeField] private float AccelerationRate = .005f;
    [SerializeField] private float DecelerationRate = .99f;
    
    private Vector3 Direction = Vector3.zero;
    private Vector3 Momentum = Vector3.zero;

    private void FixedUpdate()
    {
        HandleMomentum();
        HandleRotation();
    }

    private void HandleMomentum()
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

    private void HandleRotation()
    {
        if (Direction != Vector3.zero && Momentum != Vector3.zero)
        {
            Quaternion toRotate = Quaternion.LookRotation(
                Vector3.forward, Momentum);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, toRotate, RotateSpeed * Time.fixedDeltaTime);
        }
    }

    public void MoveTowards(Vector3 target)
    {
        Direction = (target - transform.position).normalized;
    }

    public void MoveAwayFrom(Vector3 target)
    {
        Direction = (transform.position - target).normalized;
    }

    public void StrafeAwayFrom(Transform target)
    {
        MoveAwayFrom(target.position);
        
        // To do: figure out how to determine left or right instead
    }

    public void StayStill()
    {
        Direction = Vector3.zero;
    }

}
