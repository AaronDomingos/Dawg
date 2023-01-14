using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;

public class ContainerController : NetworkBehaviour
{
    [SerializeField] private GameObject ObjectPrefab;
    [SerializeField] private Vector3 DefaultPosition;
    [SerializeField] private int StartingQuantity;
    [SerializeField] private int MaxQuantity;

    // We may need to make these lists synced.
    public List<GameObject> ActivatedObjects = new List<GameObject>();
    public List<GameObject> DeactivatedObjects = new List<GameObject>();

    /// <summary>
    /// Initializes the controller and creates all starting objects.
    /// </summary>
    public void OnServerInitialized()
    {
        Debug.Log("GameManager Started");
        for (int i = 0; i < StartingQuantity; i++)
        {
            CreateNewInstance();
        }
    }

    /// <summary>
    /// Creates a new object if max quantity has not been reached and deactivates the object.
    /// </summary>
    private void CreateNewInstance()
    {
        Debug.Log("Creating " + ObjectPrefab.name);
        if (MaxQuantity > ActivatedObjects.Count + DeactivatedObjects.Count)
        {
            GameObject newObj = Instantiate(ObjectPrefab,
                DefaultPosition, Quaternion.identity, transform);
            
            newObj.GetComponent<NetworkObject>().Spawn();
            
            //Deactivate(newObj);
            newObj.SetActive(false);
            DeactivatedObjects.Add(newObj);
            
            Debug.Log(ObjectPrefab.name + " Created");
        }
    }

    /// <summary>
    /// Tries to get the next available object. If none are available, it will attempt to create a new one.
    /// If the max quantity has already been reached, it will return null.
    /// </summary>
    /// <param name="setPosition"></param>
    /// <param name="setRotation"></param>
    /// <returns></returns>
    public GameObject GetInstance(Vector3 setPosition, Quaternion setRotation)
    {
        if (DeactivatedObjects.Count == 0)
        {
            CreateNewInstance();
        }
        if (DeactivatedObjects.Count != 0)
        {
            GameObject newObj = DeactivatedObjects[0];
            newObj.transform.position = setPosition;
            newObj.transform.rotation = setRotation;
            Activate(newObj);
            return newObj;
        }
        Debug.Log(ObjectPrefab.name + " Max Quantity Reached");
        return null;
    }

    /// <summary>
    /// Activates the object.
    /// </summary>
    /// <param name="obj"></param>
    public void Activate(GameObject obj)
    {
        if (DeactivatedObjects.Contains(obj))
        {
            ActivateByIndexServerRpc(DeactivatedObjects.IndexOf(obj));
        }
        else
        {
            Debug.Log(obj.name + "could not be found or activated");
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void ActivateByIndexServerRpc(int index)
    {
        GameObject obj = DeactivatedObjects[index];
        DeactivatedObjects.Remove(obj);
        ActivatedObjects.Add(obj);
        obj.SetActive(true);
    }

    /// <summary>
    /// Deactivates and recycles the object.
    /// </summary>
    /// <param name="obj"></param>
    public void Deactivate(GameObject obj)
    {
        if (ActivatedObjects.Contains(obj))
        {
            DeactivateByIndexServerRpc(ActivatedObjects.IndexOf(obj));
        }
        else
        {
            Debug.Log(obj.name + "could not be found or deactivated");
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void DeactivateByIndexServerRpc(int index)
    {
        GameObject obj = ActivatedObjects[index];
        obj.SetActive(false);
        ActivatedObjects.Remove(obj);
        DeactivatedObjects.Add(obj);

        obj.transform.position = DefaultPosition;
        obj.transform.rotation = Quaternion.identity;
    }
}
