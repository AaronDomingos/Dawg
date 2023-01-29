using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shot : MonoBehaviour
{
    [SerializeField] private IdDetector Detector;
    [SerializeField] private IdDetector Tracker;

    private List<Identification.Tags> TagsToCollide = 
        new List<Identification.Tags>();
    private List<Identification.Tags> TagsToDamage = 
        new List<Identification.Tags>();

    private ShotType Type;
    private GameObject Origin;
    private bool HasDamaged = false;
    private float Damage = 1;
    private float Speed = 20;
    
    private bool IsTracking = false;
    private float RotateSpeed = 5f;
    
    public enum ShotType
    {
        PlayerLarge,
        PlayerSmall,
        EnemyLarge,
        EnemySmall
    }

    public void Init( List<Identification.Tags> tagsToCollide, 
        List<Identification.Tags> tagsToDamage, GameObject origin, 
        ShotType type, float duration, float damage, float speed,
        bool isTracking, float rotationSpeed)
    {
        TagsToCollide = tagsToCollide;
        TagsToDamage = tagsToDamage;

        IsTracking = isTracking;
        RotateSpeed = rotationSpeed;
        Tracker.TagsToDetect = tagsToDamage;

        Type = type;
        Origin = origin;
        Damage = damage;
        Speed = speed;
        
        HasDamaged = false;
        Invoke("Deactivate", duration);
    }

    private void FixedUpdate()
    {
        transform.position += transform.up * Speed * Time.fixedDeltaTime;

        if (IsTracking && Tracker.DetectedObjects.Count > 0)
        {
            GameObject closestTarget = Proximity.NearestGameObject(
                gameObject, Tracker.DetectedObjects);
            transform.rotation = Orientation.QuarternionFromAToB(
                transform, closestTarget.transform.position, RotateSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == Origin) { return;}
        
        if (!HasDamaged)
        {
            if (col.gameObject.TryGetComponent(out Identity objIdentity))
            {
                if (objIdentity.TagsKnownAs.Intersect(TagsToDamage).Any() &&
                    col.gameObject.TryGetComponent(out Health objHealth))
                {
                    HasDamaged = true;
                    objHealth.Damage(Damage);
                }

                if (objIdentity.TagsKnownAs.Intersect(TagsToCollide).Any())
                {
                    CancelInvoke("Deactivate");
                    Deactivate();
                }
            }
        }
    }

    public void Deactivate()
    {
        switch (Type)
        {
            case ShotType.PlayerLarge:
                GameManager.PlayerLargeShotPool.Deactivate(gameObject);
                break;
            case ShotType.PlayerSmall:
                GameManager.PlayerSmallShotPool.Deactivate(gameObject);
                break;
            case ShotType.EnemyLarge:
                GameManager.EnemyLargeShotPool.Deactivate(gameObject);
                break;
            case ShotType.EnemySmall:
                GameManager.EnemySmallShotPool.Deactivate(gameObject);
                break;
        }
    }
}
