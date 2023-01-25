using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static GameObject MateriumContainer;
    public static GameObject AsteroidContainer;
    public static GameObject WarpGateContainer;

    public static GameObject GnatContainer;
    public static GameObject WaspContainer;
    public static GameObject BeetleContainer;

    public static GameObject BulletContainer;
    public static GameObject LaserContainer;
    public static GameObject RocketContainer;

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
        MateriumContainer = GameObject.Find("MateriumContainer");
        
        AsteroidContainer = GameObject.Find("AsteroidContainer");
        //AsteroidController = AsteroidContainer.GetComponent<ContainerController>();

        WarpGateContainer = GameObject.Find("WarpGateContainer");
        
        GnatContainer = GameObject.Find("GnatContianer");

        WaspContainer = GameObject.Find("WaspContainer");

        BeetleContainer = GameObject.Find("BeetleContainer");

        BulletContainer = GameObject.Find("BulletContainer");

        LaserContainer = GameObject.Find("LaserContainer");
        
        RocketContainer = GameObject.Find("RocketContainer");
    }
}
