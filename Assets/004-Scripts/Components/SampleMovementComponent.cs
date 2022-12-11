using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class SampleMovementComponent : NetworkBehaviour
{
    public GameObject bulletPrefab;
    
    private UserInput userInput;
    
    private void Awake()
    {
        userInput = new UserInput();
    }
    private void OnEnable()
    {
        userInput.SampleActionMap.Enable();
    }
    private void OnDisable()
    {
        userInput.SampleActionMap.Enable();
    }

    private void Update()
    {
        if (!IsOwner) return;
        
        
        Vector3 moveDirection = userInput.SampleActionMap.Move.ReadValue<Vector2>();
        transform.position += moveDirection * .1f;

        if (userInput.SampleActionMap.Fire.WasReleasedThisFrame())
        {
            GameObject spawnedObject = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            spawnedObject.GetComponent<NetworkObject>().Spawn(true);
        }
        
    }
}
