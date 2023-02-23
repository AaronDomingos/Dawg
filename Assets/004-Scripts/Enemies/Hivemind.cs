using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hivemind : MonoBehaviour
{
    public static Hivemind Instance;

    public static ObjectPool GnatPool;
    public static float GnatHealth = 5;
    public static float GnatSpeed = .7f;
    public static float GnatBiteDamage = 1;
    
    public static ObjectPool WaspPool;
    public static float WaspHealth = 20;
    public static float WaspSpeed = .4f;
    public static float WaspBiteDamage = 8;
    public static float WaspSpitDamage = 3;
    
    public static ObjectPool BeetlePool;
    public static float BeetleHealth = 50;
    public static float BeetleSpeed = .2f;
    public static float BeetleBiteDamage = 50;
    public static float BeetleSpitDamage = 10;
    public static float BeetleFartDamage = 1;
    
    public static ObjectPool SwarmPool;
    public static ObjectPool WarpGatePool;

    // [SerializeField] private GameObject SwarmPrefab;
    // public static List<Swarm> AllSwarms = new List<Swarm>();
    // public static float SwarmRange = 100;


    public List<Swarm> AvailableSwarms = new List<Swarm>();
    public float SecondsBeforeFirstActiveSwarm = 3f;
    public float SecondsBetweenActivatingSwarms = 30;
    

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
        
        InvokeRepeating("ActivateNewSwarm", SecondsBeforeFirstActiveSwarm, SecondsBetweenActivatingSwarms);
    }

    private void ActivateNewSwarm()
    {
        Debug.Log("Activating New Swarm");
        if (AvailableSwarms.Count > 0)
        {
            int index = Random.Range(0, AvailableSwarms.Count);
            AvailableSwarms[index].gameObject.SetActive(true);
            AvailableSwarms.RemoveAt(index);
            return;
        }
        Debug.Log("Failed to activate new swarm");
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
