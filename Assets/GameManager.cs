using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static Player Player;

    public static ObjectPool MateriumPool;
    public static ObjectPool LargeAsteroidPool;
    public static ObjectPool MediumAsteroidPool;
    public static ObjectPool SmallAsteroidPool;
    
    
    public static GameObject WarpGateContainer;

    public static GameObject GnatContainer;
    public static GameObject WaspContainer;
    public static GameObject BeetleContainer;

    public static GameObject BulletContainer;
    public static ObjectPool BulletPool;
    public static GameObject LaserContainer;
    public static ObjectPool LaserPool;
    public static GameObject RocketContainer;

    public static ObjectPool PlayerSmallShotPool;
    public static ObjectPool PlayerLargeShotPool;

    public static ObjectPool EnemySmallShotPool;
    public static ObjectPool EnemyLargeShotPool;
    

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
        PlayerSmallShotPool = GameObject.Find(
            "PlayerSmallShotContainer").GetComponent<ObjectPool>();
        PlayerLargeShotPool = GameObject.Find(
            "PlayerLargeShotContainer").GetComponent<ObjectPool>();
        EnemySmallShotPool = GameObject.Find(
            "EnemySmallShotContainer").GetComponent<ObjectPool>();
        EnemyLargeShotPool = GameObject.Find(
            "EnemyLargeShotContainer").GetComponent<ObjectPool>();


        LargeAsteroidPool = GameObject.Find(
            "LargeAsteroidContainer").GetComponent<ObjectPool>();
        MediumAsteroidPool = GameObject.Find(
            "MediumAsteroidContainer").GetComponent<ObjectPool>();
        SmallAsteroidPool = GameObject.Find(
            "SmallAsteroidContainer").GetComponent<ObjectPool>();

        MateriumPool = GameObject.Find(
            "MateriumContainer").GetComponent<ObjectPool>();
        
        
        Debug.Log(PlayerSmallShotPool.gameObject.name);

        BulletContainer = GameObject.Find("BulletContainer");
        BulletPool = BulletContainer.GetComponent<ObjectPool>();

        LaserContainer = GameObject.Find("LaserContainer");
        LaserPool = LaserContainer.GetComponent<ObjectPool>();
    }
}
