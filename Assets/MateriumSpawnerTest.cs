using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MateriumSpawnerTest : NetworkBehaviour
{

    [SerializeField] private GameObject materiumPrefab;


    [Command(requiresAuthority = false)]
    private void CmdSpawnMaterium()
    {
        GameObject newMaterium = Instantiate(materiumPrefab, transform.position, Quaternion.identity);
        NetworkServer.Spawn(newMaterium);
    }

    public void StartSpawningMaterium()
    {
        InvokeRepeating("CmdSpawnMaterium", 1f, 1f);
    }
}
