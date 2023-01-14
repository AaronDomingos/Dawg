using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

public class Materium : NetworkBehaviour
{
    public Vector3 Direction;
    public float Speed = 1f;
    public float Duration = 3f;
    public float SpawnTime;
    
    private void OnEnable()
    {
        RandomizeDirection();
        SpawnTime = Time.time;
    }

    private void FixedUpdate()
    {
        transform.position += Direction * Speed * Time.fixedDeltaTime;

        if (Time.time - SpawnTime > Duration)
        {
            Deactivate();
        }
    }

    private void RandomizeDirection()
    {
        Direction = new Vector3(
            Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        //Debug.Log("Direction: " + Direction);
    }

    private void Deactivate()
    {
        GameManager.AsteroidController.Deactivate(gameObject);
    }
}
