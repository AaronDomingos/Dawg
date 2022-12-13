using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Sirenix.Utilities;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static GameObject AsteroidContainer;
    public static ContainerController AsteroidController;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    private void Start()
    {
        AsteroidContainer = GameObject.Find("AsteroidContainer");
        AsteroidController = AsteroidContainer.GetComponent<ContainerController>();
        
    }
}
