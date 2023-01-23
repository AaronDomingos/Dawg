using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Materium : MonoBehaviour
{
    [SerializeField] private Movement movement;

    private void OnEnable()
    {
        SetMomentum(new Vector3( Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0));
    }
    
    
    
    
    public void SetMomentum(Vector3 momentum)
    {
        movement.SetMomentum(momentum);
    }

    public void SetAttraction(GameObject target)
    {
        movement.SetAttraction(target);
    }
}
