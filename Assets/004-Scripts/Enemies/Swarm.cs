using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.LegacyInputHelpers;
using Random = UnityEngine.Random;

public class Swarm : MonoBehaviour
{
    public int WaveNumber = 1;
    public float WaveLength = 5f;

    public IdDetector TargetPosition;
    public IdDetector PlayerDetector;
    
    public List<WarpGate> WarpGates = new List<WarpGate>();
    public List<Swarmling> Swarmlings = new List<Swarmling>();

    public bool InDanger = false;

    
    public class Wave
    {
        public int Gnats;
        public int Wasps;
        public int Beetles;
        public float TimeToSpawn;

        public Wave(int gnats, int wasps, int beetles, float time)
        {
            Gnats = gnats;
            Wasps = wasps;
            Beetles = beetles;
            TimeToSpawn = time;
        }

        public Wave(int waveNumber, float waveLength)
        {
            Gnats = waveNumber;
            Wasps = Mathf.FloorToInt(waveNumber / 5f);
            Beetles = (waveNumber < 10) ? 0 : Mathf.FloorToInt(waveNumber / 5f) - 1;
            TimeToSpawn = waveLength;
        }
    }

    private void DivideWaveBetweenWarpGates(Wave wave)
    {
        int gnatsAvailable = wave.Gnats;
        int waspsAvailable = wave.Wasps;
        int beetlesAvailable = wave.Beetles;
        foreach (WarpGate warpGate in WarpGates)
        {
            int gnats = Random.Range(0, gnatsAvailable);
            gnatsAvailable -= gnats;
            int wasps = Random.Range(0, waspsAvailable);
            waspsAvailable -= wasps;
            int beetles = Random.Range(0, beetlesAvailable);
            beetlesAvailable -= beetles;
            
            warpGate.SpawnWave(new Wave(gnats, wasps, beetles, wave.TimeToSpawn));
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnWarpGate", 5, 10);
        InvokeRepeating("SpawnWave", 10, 10);
    }

    private void FixedUpdate()
    {
        // foreach (Swarmling swarmling in Swarmlings)
        // {
        //     swarmling.Movement.MoveTowards(TargetPosition.transform.position);
        // }

        InDanger = false;
        if (PlayerDetector.DetectedObjects.Count > 0)
        {
            InDanger = true;
            TargetPosition.transform.position = 
                PlayerDetector.DetectedObjects[0].transform.position;
            return;
        }
        if (TargetPosition.DetectedObjects.Count > 0)
        {
            Vector3 randomPoint = Random.insideUnitCircle * 75f;
            TargetPosition.transform.position = transform.position + randomPoint;
        }
    }
    
    public void SpawnWarpGate()
    {
        if (WarpGates.Count < 3)
        {
            Vector3 randomPoint = Random.insideUnitCircle * 75f;
            GameObject newWarpGate = Hivemind.WarpGatePool.GetInstance(
                transform.position + randomPoint, Quaternion.identity);
            if (newWarpGate != null) ;
            {
                WarpGates.Add(newWarpGate.GetComponent<WarpGate>());
                WarpGates.Last().Init(this);
                WarpGates.Last().StartSpawningWaves();
            }
        }
    }
    
    public void SpawnWave()
    {
        Wave newWave = new Wave(WaveNumber, WaveLength);
        DivideWaveBetweenWarpGates(newWave);
        WaveNumber++;
        
        // Invoke waveattack after an amount if time.
    }

    public void WaveAttack()
    {
        
    }
}
