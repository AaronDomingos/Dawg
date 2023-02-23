using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Experimental.Rendering.Universal;

public class Satellite : DroneControl
{
    public IdDetector CollectibleDetector;

    public GameObject AbductionLight;
    

    private bool IsAuto = false;
    [SerializeField] private ShotWeapon HeavyShooter;
    
    
    
    private void FixedUpdate()
    {
        //if (IsAuto) {TryPrimaryWeapon();}
        
        if (CollectibleDetector.DetectedObjects.Count > 0)
        {
            foreach (GameObject collectible in CollectibleDetector.DetectedObjects.ToList())
            {
                if (collectible.TryGetComponent(out Identity id))
                {
                    if (id.TagsKnownAs.Contains(Identification.Tags.Materium))
                    {
                        Materium materium = collectible.GetComponent<Materium>();
                        materium.Attract(Proximity.DirectionToObject(collectible, gameObject) * 5f);
                        if (Vector3.Distance(transform.position, materium.transform.position) < 4f)
                        {
                            GameManager.Mothership.Materium += materium.Value;
                            materium.Collect();
                        }
                    }
                    if (id.TagsKnownAs.Contains(Identification.Tags.Survivors))
                    {
                        Survivor survivor = collectible.GetComponent<Survivor>();
                        survivor.Attract(Proximity.DirectionToObject(collectible,gameObject) * 5f);
                        if (Vector3.Distance(transform.position, survivor.transform.position) < 4f)
                        {
                            GameManager.Mothership.Survivors++;
                            survivor.Collect();
                        }
                    }
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
