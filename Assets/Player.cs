using System;
using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputHandler inputHandler;

    public ProCamera2D camera;

    private List<GameObject> AvailablePlayables = new List<GameObject>();

    private void Start()
    {
        
    }
    
    private void Update()
    {
        inputHandler.Handle();
    }
    
    private void AddNewPlayable(GameObject playable)
    {
        
    }

    private void RemovePlayable(GameObject playable)
    {
        
    }

    private void NextPlayable()
    {
        
    }

    private void LastPlayable()
    {
        
    }
}
