using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Materium : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigidbody;

    public int Value = 1;
    
    public void Init(Vector3 direction)
    {
        Value = 1;
        rigidbody.AddForce(direction * 25);
        
        // Set a random sprite, light, material
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(Random.Range(0, transform.childCount)).
            gameObject.SetActive(true);
    }

    public void Attract(Vector3 direction)
    {
        rigidbody.AddForce(direction);
    }

    public void Collect()
    {
        Deactivate();
    }

    private void Deactivate()
    {
        GameManager.MateriumPool.Deactivate(gameObject);
    }
}
