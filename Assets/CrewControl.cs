using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewControl : MonoBehaviour
{
    [SerializeField] private CrewInputHandler input;
    [SerializeField] private float Speed = .25f;
    
    private void Update()
    {
        input.Handle();
    }
    
    public void ApplyWalk(Vector3 direction)
    {
        transform.position += direction * Speed;
    }
}
