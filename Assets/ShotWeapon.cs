using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotWeapon : MonoBehaviour
{
    [SerializeField] private GameObject ShotPrefab;
    
    [SerializeField] private List<Identification.Tags> TagsToCollide = 
        new List<Identification.Tags>();
    [SerializeField] private List<Identification.Tags> TagsToDamage = 
        new List<Identification.Tags>();

    [SerializeField] private GameObject Origin;
    [SerializeField] private float Duration = 3f;
    [SerializeField] private float Damage = 1f;
    [SerializeField] private float Speed = 20f;

    [SerializeField] private bool IsTracking = false;
    [SerializeField] private float RotationSpeed = 5f;

    [SerializeField] private float Cooldown = 1f;
    [SerializeField] private bool IsCooled = true;

    public void TryFire()
    {
        if (IsCooled)
        {
            GameObject newShot = Instantiate(ShotPrefab,
                transform.position, transform.rotation, null);
            
            if (newShot != null)
            {
                newShot.GetComponent<Shot>().Init(TagsToCollide, TagsToDamage,
                    Origin, Duration, Damage, Speed, IsTracking, RotationSpeed);
                StartCoroutine(CooldownTimer());
            }
        }
    }
    
    public IEnumerator CooldownTimer()
    {
        IsCooled = false;
        yield return new WaitForSeconds(Cooldown);
        IsCooled = true;
    }
    
}
