using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitTest : MonoBehaviour
{
    [SerializeField] private float Speed = 100f; 
    private Vector3 CenterPoint;
    
    void Start()
    {
        CenterPoint = Vector3.zero;
    }

    void Update()
    {
        transform.RotateAround(CenterPoint, Vector3.back, Speed * Time.deltaTime);
    }
}
