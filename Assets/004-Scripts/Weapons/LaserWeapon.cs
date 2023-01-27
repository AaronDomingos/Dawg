using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class LaserWeapon : Weapon
{
    public Laser laser;
    public bool IsFiring = false;

    public List<Identification.Tags> CollidibleTags =
        new List<Identification.Tags>();
    public List<Identification.Tags> DamagableTags =
        new List<Identification.Tags>();
    public Identification.Tags Shooter;
    
    public float Range = 10f;
    public float MaxTime = 3f;
    public float TimeActive = 0f;
    public bool OverHeated = false;
    public float CooldownRate = .5f;
    public float DamagePerSecond = 5f;
    
    [ColorUsage(true, true)]
    public Color LaserColor = Color.red;
    
    private void OnEnable()
    {
        laser = null;
    }

    private void OnDisable()
    {
        DeactivateLaser();
    }

    private void Update()
    {
        UpdateTemp();
    }

    private void UpdateTemp()
    { 
        if (IsFiring)
        {   // Add time spent firing.
            TimeActive = math.clamp(TimeActive + Time.deltaTime, 0, MaxTime);
        }
        else
        {   // Cooldown
            if (OverHeated)
            {   // Coolsdown half as fast as normal if Overheated.                       
                TimeActive = math.clamp(TimeActive - (Time.deltaTime * (CooldownRate * .5f)), 0, MaxTime);
            }
            else
            {
                TimeActive = math.clamp(TimeActive - (Time.deltaTime * CooldownRate), 0, MaxTime);
            }
        }
        
        if (TimeActive >= MaxTime)
        {   // Max time reached.
            OverHeated = true;
            DeactivateLaser(); 
        }
        else if (TimeActive <= 0)
        {
            OverHeated = false;
        }
    }

    private void ActivateLaser()
    {
        laser = GameManager.LaserPool.GetInstance(
            transform.position, Orientation.Default).GetComponent<Laser>();
        if (laser != null)
        {
            laser.Init(CollidibleTags, DamagableTags, Shooter, 
                Range, DamagePerSecond, LaserColor);
            IsFiring = true;
        }
    }

    public void DeactivateLaser()
    {
        if (laser != null)
        {
            GameManager.LaserPool.Deactivate(laser.gameObject);
            laser = null;
            IsFiring = false;
        }
    }
    
    public override void TryFire(Vector3 target)
    {
        if (!OverHeated)
        {
            if (!IsFiring)
            {
                ActivateLaser();
            }

            if (laser != null)
            {
                laser.SetPoints(transform.position, target);
            }
        }
    }
}
