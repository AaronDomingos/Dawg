using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarm : MonoBehaviour
{
    private void FixedUpdate()
    {
        
    }



    // Will not work as is, bad approach..
    private void MoveSwarm()
    {
        Vector3 initialPosition = transform.position;
        Vector3 futurePosition = Vector3.zero;
        
        foreach (Transform swarmling in transform)
        {
            futurePosition += swarmling.position;
        }

        transform.position = futurePosition / transform.childCount;
    }

    private void SwarmMovement()
    {
        
    }
}
