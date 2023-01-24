using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MateriumSpawnerTest : MonoBehaviour
{

    [SerializeField] private GameObject materiumPrefab;


    private void CmdSpawnMaterium()
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
        InvokeRepeating("CmdSpawnMaterium", 1f, 1f);
    }
}
