using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Materium : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigidbody;
    

    public void Init()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(Random.Range(0, transform.childCount)).
            gameObject.SetActive(true);
        
        rigidbody.AddForce(new Vector2(
            Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
    }
    
    
}
