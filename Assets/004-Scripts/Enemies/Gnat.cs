using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Gnat : Swarmling
{
    [SerializeField] private IdDetector AvoidanceZone;
    [SerializeField] private IdDetector HuntingZone;
    [SerializeField] private IdDetector BiteZone;
    [SerializeField] private MeleeWeapon Bite;


    [SerializeField] private EnemyMovement Movement;
    [SerializeField] private Health Health;

    private string GnatName = "Gnat";

    public void Init()
    {
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
        HandleMySwarm();
        HandleMovement();
        HandleMandibles();
    }

    private void HandleMovement()
    {
        // If needs to avoid something
        if (AvoidanceZone.DetectedObjects.Count > 0)
        {
            GameObject closestObject = Proximity.NearestGameObject(
                gameObject, AvoidanceZone.DetectedObjects);
            
            Movement.StrafeAwayFrom(closestObject.transform);
            return;
        }
        
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
            HandleSwarmMovement();
            return;
        }
        
        // Default to mothership
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
        Hivemind.GnatPool.Deactivate(gameObject);
    }
}
