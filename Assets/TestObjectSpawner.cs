using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TestObjectSpawner : NetworkBehaviour
{
    public GameObject objectPrefab;
    public GameObject objectInstance;

    [ServerRpc(RequireOwnership = false)]
    public void SpawnObjectServerRpc(Vector3 position)
    {
        Debug.Log("Spawning Object");
        GameObject newObject = Instantiate(
            objectPrefab, position, Quaternion.identity);
            
        newObject.GetComponent<NetworkObject>().Spawn();
        objectInstance = newObject;
    }
}
