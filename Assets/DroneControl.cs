using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneControl : MonoBehaviour
{
    [SerializeField] private DroneInputHandler input;
    [SerializeField] private float Speed = .25f;
    
    private void Update()
    {
        input.Handle();
    }
    
    public void ApplyThrust(Vector3 direction)
    {
        transform.position += direction * Speed;
    }
}
