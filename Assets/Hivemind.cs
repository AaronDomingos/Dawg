using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hivemind : MonoBehaviour
{
    public static Hivemind Instance;

    public static ObjectPool GnatPool;
    public static float GnatHealth = 3;
    public static float GnatSpeed = .7f;
    public static float GnatBiteDamage = 1;
    
    public static ObjectPool WaspPool;
    public static float WaspHealth = 30;
    public static float WaspSpeed = .4f;
    public static float WaspBiteDamage = 8;
    public static float WaspSpitDamage = 3;
    
    public static ObjectPool BeetlePool;
    public static float BeetleHealth = 300;
    public static float BeetleSpeed = .2f;
    public static float BeetleBiteDamage = 50;
    public static float BeetleSpitDamage = 10;
    public static float BeetleFartDamage = 1;
    
    
    
    public static ObjectPool SwarmPool;

    [SerializeField] private GameObject SwarmPrefab;
    public static List<Swarm> AllSwarms = new List<Swarm>();
    public static float SwarmRange = 100;


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
        GnatPool = transform.Find("GnatContainer").GetComponent<ObjectPool>();
        WaspPool = transform.Find("WaspContainer").GetComponent<ObjectPool>();
        BeetlePool = transform.Find("BeetleContainer").GetComponent<ObjectPool>();
        SwarmPool = transform.Find("SwarmContainer").GetComponent<ObjectPool>();
    }

    public static Swarm FindClosestSwarm(GameObject swarmling)
    {
        // Order by proximity
        if (true)
        {
            return null;
        }
        
        // else
        // {
        //     return CreateNewSwarm(swarmling.transform.position);
        // }
    }

    private static Swarm CreateNewSwarm(Vector3 position)
    {
        GameObject newSwarm = SwarmPool.GetInstance(
            position, Quaternion.identity);
        newSwarm.name = "Swarm";
        return newSwarm.GetComponent<Swarm>();
    }
}
