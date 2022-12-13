using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateriumSpawner : MonoBehaviour
{
    void Start()
    {
        //InvokeRepeating("SpawnMaterium", 0f, 1f);
    }

    private void SpawnMaterium()
    {
        GameManager.AsteroidController.GetInstance(transform.position, Quaternion.identity);
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnMaterium", 0f, 1f);
    }
}
