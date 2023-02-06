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
    public static ObjectPool WarpGatePool;

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
        GnatPool = transform.Find("GnatPool").GetComponent<ObjectPool>();
        WaspPool = transform.Find("WaspPool").GetComponent<ObjectPool>();
        BeetlePool = transform.Find("BeetlePool").GetComponent<ObjectPool>();
        SwarmPool = transform.Find("SwarmPool").GetComponent<ObjectPool>();
        WarpGatePool = transform.Find("WarpGatePool").GetComponent<ObjectPool>();
        
        //InvokeRepeating("OpenWarpGates", 1, 5);
    }

    private void OpenWarpGates()
    {
        // Vector3 spawnPoint = (Random.insideUnitCircle.normalized * 175) + 
        //                      (Random.insideUnitCircle.normalized * 25);
        //
        // GameObject newWarpGate = WarpGatePool.GetInstance(spawnPoint, Quaternion.identity);
        // newWarpGate.GetComponent<WarpGate>().Init();
    }
}
