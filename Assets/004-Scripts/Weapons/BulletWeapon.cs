using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeapon : Weapon
{
    public List<Identification.Tags> TagsItCollidesWith = 
        new List<Identification.Tags>();
    public List<Identification.Tags> TagsItCanDamage = 
        new List<Identification.Tags>();

    public Identification.Tags Shooter;
    
    public float Duration = 3f;
    public float Damage = 1f;
    public float Speed = .02f;
    public float Size = .4f;
    public Color Color = Color.white;

    public float Cooldown = 1f;
    public bool IsCooled = true;

    public override void TryFire(Vector3 direction)
    {
        if (IsCooled)
        {
            GameObject newBullet = GameManager.BulletPool.GetInstance(
                transform.position, Orientation.Default);
            if (newBullet != null)
            {
                newBullet.GetComponent<Bullet>().Init(TagsItCollidesWith, TagsItCanDamage, 
                    Shooter, direction, Duration, Damage, Speed, Size, Color);
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
