using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public Vector3 DefaultPosition;
    public float StartingQuantity = 1;
    public float MaxQuantity = 10;

    public List<GameObject> EnabledObjects = new List<GameObject>();
    public List<GameObject> DisabledObjects = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < StartingQuantity; i++)
        {
            CreateNewInstance();
        }
    }

    private void CreateNewInstance()
    {
        if (MaxQuantity > EnabledObjects.Count + DisabledObjects.Count)
        {
            GameObject newObj = Instantiate(ObjectPrefab,
                DefaultPosition, Orientation.Default, transform);
            Deactivate(newObj);
        }
    }

    public GameObject GetInstance(Vector3 setPosition, Quaternion setRotation)
    {
        if (DisabledObjects.Count == 0)
        {
            CreateNewInstance();
        }
        if (DisabledObjects.Count != 0)
        {
            GameObject newObj = DisabledObjects[0];
            newObj.transform.position = setPosition;
            newObj.transform.rotation = setRotation;
            Activate(newObj);
            return newObj;
        }
        Debug.Log(ObjectPrefab.name + " Limit Reached!");
        return null;
    }

    public void Activate(GameObject obj)
    {
        DisabledObjects.Remove(obj);
        EnabledObjects.Add(obj);
        obj.SetActive(true);
    }
    
    public void Deactivate(GameObject obj)
    {
        obj.transform.position = DefaultPosition;
        obj.transform.rotation = Orientation.Default;
        EnabledObjects.Remove(obj);
        DisabledObjects.Add(obj);
        obj.SetActive(false);
    }

    public void DestroyInstance(GameObject obj)
    {
        
    }
}
