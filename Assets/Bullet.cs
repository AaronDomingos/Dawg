using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bullet : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Identity identity;
    
    private List<Identification.Tags> TagsItCollidesWith = 
        new List<Identification.Tags>();
    private List<Identification.Tags> TagsItCanDamage = 
        new List<Identification.Tags>();

    private Identification.Tags Shooter;
    private Vector3 Direction = Vector3.zero;
    private float Damage = 1f;
    private float Speed = .02f;

    private bool HasDamaged = false;

    private void OnDisable()
    {
        SetDefault();
    }
    
    public void Init(List<Identification.Tags> tagsItCollidesWith, 
        List<Identification.Tags> tagsItCanDamage, Identification.Tags shooter, 
        Vector3 direction, float duration, float damage, float speed, float size, Color color)
    {
        TagsItCollidesWith = tagsItCollidesWith;
        TagsItCanDamage = tagsItCanDamage;
        Direction = direction;
        Damage = damage;
        Speed = speed;

        sprite.color = color;
        identity.Add(shooter);
        transform.localScale = new Vector3(size, size);

        HasDamaged = false;
        Invoke("Deactivate", duration);
    }
    
    void FixedUpdate()
    {
        transform.localPosition += Direction * Speed;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!HasDamaged)
        {
            if (col.gameObject.TryGetComponent(out Identity objIdentity))
            {
                // if (objIdentity.TagsKnownAs.Intersect(TagsItCanDamage).Any() &&
                //     col.gameObject.TryGetComponent(out Health objHealth))
                // {
                //     HasDamaged = true;
                //     objHealth.Damage(Damage);
                // }

                if (objIdentity.TagsKnownAs.Intersect(TagsItCollidesWith).Any())
                {
                    CancelInvoke("Deactivate");
                    Deactivate();
                }
            }
        }
    }

    private void SetDefault()
    {
        identity.Remove(Shooter);
        sprite.color = Color.white;
        Direction = Vector3.zero;
    }
    
    private void Deactivate()
    {
        SetDefault();
        GameManager.BulletPool.Deactivate(gameObject);
    }
}
