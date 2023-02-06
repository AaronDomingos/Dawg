using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Gnat : Swarmling
{
    [SerializeField] private IdDetector HuntingZone;
    [SerializeField] private IdDetector BiteZone;
    [SerializeField] private MeleeWeapon Bite;
    [SerializeField] private Health Health;
    
    private string GnatName = "Gnat";

    public void Init(Swarm swarm)
    {
        MySwarm = swarm;
        MySwarm.Swarmlings.Add(this);
        Health.Init(Hivemind.GnatHealth);
        Movement.MaximumSpeed = Hivemind.GnatSpeed;
        Bite.Damage = Hivemind.GnatBiteDamage;
    }
    
    private void Start()
    {
        gameObject.name = GnatName;
        transform.SetParent(Hivemind.GnatPool.transform);
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleMandibles();
    }

    private void HandleMovement()
    {
        // If there's a player in the swarm's radius
        if (MySwarm.InDanger)
        {
            Movement.MoveTowards(MySwarm.TargetPosition.transform.position);
            return;
        }
        
        // Gnats don't avoid things.
        
        // If Hunting
        if (HuntingZone.DetectedObjects.Count > 0)
        {
            GameObject closestTarget = Proximity.NearestGameObject(
                gameObject, HuntingZone.DetectedObjects);
            
            Movement.MoveTowards(closestTarget.transform.position);
            return;
        }

        if (MySwarm != null)
        {
            Movement.MoveTowards(MySwarm.TargetPosition.transform.position);
            return;
        }
        
        // Default to stay still
        Movement.StayStill();
    }

    private void HandleMandibles()
    {
        if (BiteZone.DetectedObjects.Count > 0)
        {
            Bite.TryMelee();
        }
    }

    private void OnStatusDestroy()
    {
        MySwarm.Swarmlings.Remove(this);
        MySwarm = null;
        Hivemind.GnatPool.Deactivate(gameObject);
    }
}
