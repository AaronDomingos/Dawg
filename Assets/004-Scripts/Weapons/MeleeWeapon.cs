using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{

    [SerializeField] private IdDetector MeleeZone;
    public float Damage;
    
    [SerializeField] private float Cooldown;
    private bool IsCooled = true;

    public void TryMelee()
    {
        if (IsCooled)
        {
            foreach (GameObject target in MeleeZone.DetectedObjects)
            {
                if (target.TryGetComponent(out Health targetHealth))
                {
                    targetHealth.Damage(Damage);
                }
            }
            StartCoroutine("CooldownTimer");
        }
    }
    
    public IEnumerator CooldownTimer()
    {
        IsCooled = false;
        yield return new WaitForSeconds(Cooldown);
        IsCooled = true;
    }
}
