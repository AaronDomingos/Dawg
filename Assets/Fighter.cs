using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : DroneControl
{
    [SerializeField] private ShotWeapon HeavyShooter;
    [SerializeField] private ShotWeapon SmallShooterA;
    [SerializeField] private ShotWeapon SmallShooterB;

    private bool IsAuto = false;
    
    
    
    private void FixedUpdate()
    {
        if (IsAuto) {TryPrimaryWeapon();}
    }

    public override void TryPrimaryWeapon()
    {
        HeavyShooter.TryFire();
        SmallShooterA.TryFire();
        SmallShooterB.TryFire();
    }

    public override void ActivateAutoPilot()
    {
        IsAuto = true;
    }

    public override void DeactivateAutoPilot()
    {
        IsAuto = false;
    }

    private void OnStatusDestroy()
    {
        transform.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
