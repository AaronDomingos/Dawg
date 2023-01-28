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
    
    private GameObject Origin;
    private bool HasDamaged = false;
    private float Damage = 1;
    private float Speed = 20;
    
    private bool IsTracking = false;
    private float RotateSpeed = 5f;

    public void Init(List<Identification.Tags> tagsToCollide, 
        List<Identification.Tags> tagsToDamage, GameObject origin, 
        float duration, float damage, float speed,
        bool isTracking, float rotationSpeed)
    {
        TagsToCollide = tagsToCollide;
        TagsToDamage = tagsToDamage;

        IsTracking = isTracking;
        RotateSpeed = rotationSpeed;
        Tracker.TagsToDetect = tagsToDamage;

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
                // if (objIdentity.TagsKnownAs.Intersect(TagsItCanDamage).Any() &&
                //     col.gameObject.TryGetComponent(out Health objHealth))
                // {
                //     HasDamaged = true;
                //     objHealth.Damage(Damage);
                // }

                if (objIdentity.TagsKnownAs.Intersect(TagsToCollide).Any())
                {
                    Debug.Log("Collided with: " + col.gameObject.name);
                    CancelInvoke("Deactivate");
                    Deactivate();
                }
            }
        }
    }

    public void Deactivate()
    {
        Destroy(gameObject);
    }
}
