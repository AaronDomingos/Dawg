using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Miner : DroneControl
{
    public IdDetector MateriumDetector;
    

    private bool IsAuto = false;
    
    
    
    private void FixedUpdate()
    {
        if (IsAuto) {TryPrimaryWeapon();}
        
        if (MateriumDetector.DetectedObjects.Count > 0)
        {
            foreach (GameObject materium in MateriumDetector.DetectedObjects.ToList())
            {
                Materium script = materium.GetComponent<Materium>();
                script.Attract(Proximity.DirectionToObject(materium, gameObject) * 10f);
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
        // Laser Drill
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
