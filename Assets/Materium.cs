using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

public class Materium : NetworkBehaviour
{
    [SerializeField] private Movement movement;

    private void OnEnable()
    {
        SetMomentum(new Vector3( Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0));
        Invoke("Deactivate", 3f);
    }
    
    
    
    
    public void SetMomentum(Vector3 momentum)
    {
        movement.SetMomentum(momentum);
    }

    public void SetAttraction(GameObject target)
    {
        movement.SetAttraction(target);
    }
    
    public void Deactivate()
    {
        Debug.Log("Deactivating ClientRpcDeactivate on: " + gameObject.name);
        CancelInvoke("Deactivate");
        gameObject.SetActive(false);
        
        if (isServer)
        {
            GameManager.MateriumPool.ReturnInstance(gameObject);
            return;
        }
        Debug.Log("Ignoring Deactivate Here");
    }

    [Server]
    public void Activate()
    {
        gameObject.SetActive(true);
    }
}
