using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    public int Value = 1;

    public void Init(Vector3 direction)
    {
        Value = 1;
        rigidbody.AddForce(direction * 25);
    }
    
    public void Attract(Vector3 direction)
    {
        rigidbody.AddForce(direction);
    }

    public void Collect()
    {
        Destroy(gameObject);
    }
}
