using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Fighter : DroneControl
{

    public IdDetector MateriumDetector;
    
    
    [SerializeField] private ShotWeapon HeavyShooter;
    [SerializeField] private ShotWeapon SmallShooterA;
    [SerializeField] private ShotWeapon SmallShooterB;

    private bool IsAuto = false;
    
    
    
    private void FixedUpdate()
    {
        if (IsAuto) {TryPrimaryWeapon();}
        
        if (MateriumDetector.DetectedObjects.Count > 0)
        {
            foreach (GameObject materium in MateriumDetector.DetectedObjects.ToList())
            {
                Materium script = materium.GetComponent<Materium>();
                script.Attract(Proximity.DirectionToObject(materium, gameObject) * 5f);
                if (Vector3.Distance(transform.position, materium.transform.position) < 4f)
                {
                    GameManager.Mothership.Materium += script.Value;
                    script.Collect();
                }
            }
        }
    }

    public void OnCollect(int materiumValue)
    {
        GameManager.Mothership.Materium += materiumValue;
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
