using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Wasp : Swarmling
{
    [SerializeField] private IdDetector AvoidanceZone;
    [SerializeField] private IdDetector HuntingZone;
    [SerializeField] private IdDetector BiteZone;
    [SerializeField] private MeleeWeapon Bite;

    [SerializeField] private IdDetector SpitZone;
    [SerializeField] private ShotWeapon Spit;
    
    [SerializeField] private EnemyMovement Movement;
    [SerializeField] private Health Health;

    private string WaspName = "Wasp";

    public bool IsAttached = false;
    private Transform AttachedAsteroid;
    
    private float CurrentMaterium = 0;
    private float RequiredMaterium = 20;

    public void Init()
    {
        Health.Init(Hivemind.WaspHealth);
        Movement.MaximumSpeed = Hivemind.WaspSpeed;
        Bite.Damage = Hivemind.WaspBiteDamage;
        Spit.Damage = Hivemind.WaspSpitDamage;
    }
    
    private void Start()
    {
        gameObject.name = WaspName;
        transform.SetParent(Hivemind.GnatPool.transform);
        
    }

    private void FixedUpdate()
    {
        HandleMySwarm();
        HandleMovement();
        HandleMandibles();
        HandleSpitter();
    }

    private void HandleMovement()
    {
        if (IsAttached)
        {
            return;
        }
        
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

        // If Asteroid in Range
        if (true )
        {
            return;
        }
        
        // Swarm Actions
        if (MySwarm != null)
        {
            HandleSwarmMovement();
            return;
        }
        Movement.StayStill();
    }

    private void HandleMandibles()
    {
        if (BiteZone.DetectedObjects.Count > 0)
        {
            if (BiteZone.DetectedObjects[0].TryGetComponent(out Asteroid asteroid))
            {
                if (!IsAttached)
                {
                    AttachToObject(asteroid.transform);
                }
                HarvestMaterium();
                return;
            }
            Bite.TryMelee();
        }
    }

    private void HandleSpitter()
    {
        if (SpitZone.DetectedObjects.Count > 0)
        {
            Spit.TryFire();
        }
    }

    private void AttachToObject(Transform asteroid)
    {
        AttachedAsteroid = asteroid;
        transform.SetParent(asteroid);
        Movement.enabled = false;
    }

    private void DetachFromObject(Transform asteroid)
    {
        AttachedAsteroid = null;
        transform.SetParent(Hivemind.WaspPool.transform);
        Movement.enabled = true;
    }

    private void HarvestMaterium()
    {
        
    }

    private void OnAsteroidDestroyed()
    {
        DetachFromObject(AttachedAsteroid);
    }

    
    private void OnStatusDestroy()
    {
        Hivemind.GnatPool.Deactivate(gameObject);
    }
}
