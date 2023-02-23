using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static PlayerManager Player;
    public static MothershipManager Mothership;

    public static ObjectPool MateriumPool;
    public static ObjectPool LargeAsteroidPool;
    public static ObjectPool MediumAsteroidPool;
    public static ObjectPool SmallAsteroidPool;
    
    public static ObjectPool LaserPool;

    public static ObjectPool PlayerSmallShotPool;
    public static ObjectPool PlayerLargeShotPool;
    public static ObjectPool EnemySmallShotPool;
    public static ObjectPool EnemyLargeShotPool;

    public static ObjectPool PlayerBeamPool;
    public static ObjectPool EnemyBeamPool;

    public static ObjectPool PlayerSmallRocketPool;
    public static ObjectPool PlayerLargeRocketPool;

    public bool isGameOver = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            //DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    private void Start()
    {
        Player = GameObject.Find(
            "PlayerManager").GetComponent<PlayerManager>();
        Mothership = GameObject.Find(
            "MothershipManager").GetComponent<MothershipManager>();
        
        PlayerSmallShotPool = GameObject.Find(
            "PlayerSmallShotPool").GetComponent<ObjectPool>();
        PlayerLargeShotPool = GameObject.Find(
            "PlayerLargeShotPool").GetComponent<ObjectPool>();
        EnemySmallShotPool = GameObject.Find(
            "EnemySmallShotPool").GetComponent<ObjectPool>();
        EnemyLargeShotPool = GameObject.Find(
            "EnemyLargeShotPool").GetComponent<ObjectPool>();
        
        LargeAsteroidPool = GameObject.Find(
            "LargeAsteroidPool").GetComponent<ObjectPool>();
        MediumAsteroidPool = GameObject.Find(
            "MediumAsteroidPool").GetComponent<ObjectPool>();
        SmallAsteroidPool = GameObject.Find(
            "SmallAsteroidPool").GetComponent<ObjectPool>();
        MateriumPool = GameObject.Find(
            "MateriumPool").GetComponent<ObjectPool>();

        PlayerBeamPool = GameObject.Find(
            "PlayerBeamPool").GetComponent<ObjectPool>();
        EnemyBeamPool = GameObject.Find(
            "EnemyBeamPool").GetComponent<ObjectPool>();
        
        PlayerSmallRocketPool = GameObject.Find(
            "PlayerSmallRocketPool").GetComponent<ObjectPool>();
        PlayerLargeRocketPool = GameObject.Find(
            "PlayerLargeRocketPool").GetComponent<ObjectPool>();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("MetricsMenu", LoadSceneMode.Additive);
    }
}
