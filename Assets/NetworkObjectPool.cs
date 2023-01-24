using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;
using UnityEngine.Networking.Types;

public class NetworkObjectPool : NetworkBehaviour
{
   
    [SerializeField] private string ObjectName;
    [SerializeField] private GameObject ObjectPrefab;
    [SerializeField] private Vector3 DefaultPosition;
    [SerializeField] private int StartingQuantity;
    [SerializeField] private int MaxQuantity;

    public List<GameObject> AllObjects = new List<GameObject>();
    public List<int> ActiveIds = new List<int>();
    public List<int> InactiveIds = new List<int>();
    private int Count = 0;

    private void Initialize()
    {
        for (int i = 0; i < StartingQuantity; i++)
        {
            CreateNewInstance();
        }
    }

    public GameObject ReserveInstance()
    {
        if (InactiveIds.Count == 0)
        {
            CreateNewInstance();
            if (InactiveIds.Count == 0)
            {
                Debug.Log("Failed to reserve: " + ObjectName);
                return null;
            }
        }
        
        int firstAvailableId = InactiveIds[0];
        //Debug.Log("Reserved " + ObjectName + " ID: " + firstAvailableId);
        
        SpawnInstance(firstAvailableId);
        return AllObjects[firstAvailableId];
    }

    public void ReturnInstance(GameObject obj)
    {
        if (!AllObjects.Contains(obj))
        {
            Debug.Log("Could not return " + obj.name + " to " + gameObject.name);
            return;
        }

        int objId = AllObjects.IndexOf(obj);
        //Debug.Log("Returning " + ObjectName + objId);
        DespawnInstance(objId);
    }
    
    [Server]
    private void CreateNewInstance()
    {
        //Debug.Log(Count + "/" + MaxQuantity);
        if (Count >= MaxQuantity)
        {
            Debug.Log(ObjectName + " max quantity reached");
            return;
        }

        GameObject newObj = Instantiate(ObjectPrefab, DefaultPosition, Quaternion.identity);
        AllObjects.Add(newObj);
        
        newObj.transform.SetParent(transform);
        newObj.transform.position = DefaultPosition;
        newObj.name = ObjectName + Count;
        
        SpawnInstance(Count);
        DespawnInstance(Count);
        Count++;
    }

    [Server]
    private void SpawnInstance(int objId)
    {
        ActiveIds.Add(objId);
        InactiveIds.Remove(objId);
        NetworkServer.Spawn(AllObjects[objId]);
    }

    [Server]
    private void DespawnInstance(int objId)
    {
        
        InactiveIds.Add(objId);
        ActiveIds.Remove(objId);
        NetworkServer.UnSpawn(AllObjects[objId]);
    }
}
