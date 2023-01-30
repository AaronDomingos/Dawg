using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarmling : MonoBehaviour
{
    public Swarm MySwarm;
    private bool ShouldCheckSwarm = true;
    private float SwarmCheckCooldown = 5f;

    private void OnEnable()
    {
        ShouldCheckSwarm = true;
    }

    private void OnDisable()
    {
        ShouldCheckSwarm = false;
    }

    public void HandleSwarmMovement()
    {
        Debug.Log("Swarm Movement Requested");
    }
    
    public void HandleMySwarm()
    {
        if (ShouldCheckSwarm)
        {
            MySwarm = Hivemind.FindClosestSwarm(gameObject);
            StartCoroutine("CooldownTimer");
            ShouldCheckSwarm = false;
        }
    }
    
    public IEnumerator CooldownTimer()
    {
        ShouldCheckSwarm = false;
        yield return new WaitForSeconds(SwarmCheckCooldown);
        ShouldCheckSwarm = true;
    }
}
