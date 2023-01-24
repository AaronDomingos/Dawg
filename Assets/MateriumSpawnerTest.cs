using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MateriumSpawnerTest : MonoBehaviour
{

    [SerializeField] private GameObject materiumPrefab;
    
    private void SpawnMaterium()
    {
        GameObject newMaterium = GameManager.MateriumPool.ReserveInstance();
        if (newMaterium != null)
        {
            newMaterium.transform.position = transform.position;
            newMaterium.GetComponent<Materium>().Activate();
        }
    }

    public void StartSpawningMaterium()
    {
        InvokeRepeating("SpawnMaterium", 1f, 1f);
    }

    public void SpawnSingleMaterium()
    {
        SpawnMaterium();
    }
}
