using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotWeapon : MonoBehaviour
{

    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip clip;
    
    [SerializeField] private Shot.ShotType WeaponShotType;
    
    [SerializeField] private List<Identification.Tags> TagsToCollide = 
        new List<Identification.Tags>();
    [SerializeField] private List<Identification.Tags> TagsToDamage = 
        new List<Identification.Tags>();

    [SerializeField] private GameObject Origin;
    [SerializeField] private float Duration = 3f;
    public float Damage = 1f;
    [SerializeField] private float Speed = 20f;

    [SerializeField] private bool IsTracking = false;
    [SerializeField] private float RotationSpeed = 5f;

    [SerializeField] private float Cooldown = 1f;
    [SerializeField] private bool IsCooled = true;

    public void TryFire()
    {
        if (IsCooled)
        {
            GameObject newShot = null;
            switch (WeaponShotType)
            {
                case Shot.ShotType.PlayerLarge:
                    newShot = GameManager.PlayerLargeShotPool.GetInstance(
                        transform.position, transform.rotation);
                    break;
                case Shot.ShotType.PlayerSmall:
                    newShot = GameManager.PlayerSmallShotPool.GetInstance(
                        transform.position, transform.rotation);
                    break;
                case Shot.ShotType.EnemyLarge:
                    newShot = GameManager.EnemyLargeShotPool.GetInstance(
                        transform.position, transform.rotation);
                    break;
                case Shot.ShotType.EnemySmall:
                    newShot = GameManager.EnemySmallShotPool.GetInstance(
                        transform.position, transform.rotation);
                    break;
            }
            
            if (newShot != null)
            {
                newShot.GetComponent<Shot>().Init(TagsToCollide, TagsToDamage,
                    Origin, WeaponShotType, Duration, Damage, Speed, IsTracking, RotationSpeed);
                StartCoroutine(CooldownTimer());
                audio.PlayOneShot(clip);
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
