using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : Swarmling
{
    [SerializeField] private IdDetector HuntingZone;
    [SerializeField] private IdDetector BiteZone;
    [SerializeField] private MeleeWeapon Bite;
    [SerializeField] private IdDetector SpitZone;
    [SerializeField] private ShotWeapon Spit;
    [SerializeField] private IdDetector FartZone;
    [SerializeField] private MeleeWeapon Fart;
    
    [SerializeField] private Health Health;

    private string BeetleName = "Beetle";

    private bool IsAttached = false;

    public void Init(Swarm swarm)
    {
        MySwarm = swarm;
        MySwarm.Swarmlings.Add(this);
        
        Health.Init(Hivemind.BeetleHealth);
        Movement.MaximumSpeed = Hivemind.BeetleSpeed;
        Bite.Damage = Hivemind.BeetleBiteDamage;
        Spit.Damage = Hivemind.BeetleSpitDamage;
        Fart.Damage = Hivemind.BeetleFartDamage;
    }
    
    private void Start()
    {
        gameObject.name = BeetleName;
        transform.SetParent(Hivemind.BeetlePool.transform);
        
    }

    private void FixedUpdate()
    {
        HandleMovement();
        //HandleMandibles();
    }

    private void HandleMovement()
    {
        return;
        
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
            if (BiteZone.DetectedObjects[0])
            {
                
            }

            Bite.TryMelee();
        }
    }

    private void AttachToObject(Transform target)
    {
        
    }

    private void OnStatusDamaged()
    {
        //Gas'em!
    }

    private void OnStatusCritical()
    {
        //Gas'em again!
    }
    
    
    private void OnStatusDestroy()
    {
        MySwarm.Swarmlings.Remove(this);
        MySwarm = null;
        
        Hivemind.GnatPool.Deactivate(gameObject);
    }
    
}
