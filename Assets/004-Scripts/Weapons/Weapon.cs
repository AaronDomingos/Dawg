using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private float RotateSpeed = 50f;
    
    [SerializeField] private GameObject BulletPrefab;
    
    public void FollowTarget(GameObject target)
    {
        Quaternion toRotate = Quaternion.LookRotation(
            Vector3.forward, Proximity.DirectionToObject(gameObject, target));
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation, toRotate, RotateSpeed * Time.fixedDeltaTime);
    }

    public void TryFire()
    {
        
    }
}
