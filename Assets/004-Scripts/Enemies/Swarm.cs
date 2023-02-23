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
    public float WaveGenerationTime = 5f;
    public float TimeBeforeAttack = 30f;
    public float TimeBetweenWaves = 60f;

    public IdDetector TargetPosition;
    public IdDetector PlayerDetector;
    
    public List<WarpGate> WarpGates = new List<WarpGate>();
    public List<Swarmling> Swarmlings = new List<Swarmling>();

    public bool InDanger = false;
    public bool IsAttacking = false;

    
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

        for (int i = 0; i < WarpGates.Count; i++)
        {
            int gnats = wave.Gnats / WarpGates.Count;
            gnatsAvailable -= gnats;
            int wasps = wave.Wasps / WarpGates.Count;
            waspsAvailable -= wasps;
            int beetles = wave.Beetles / WarpGates.Count;
            beetlesAvailable -= beetles;

            if (i == WarpGates.Count - 1)
            {
                WarpGates[i].SpawnWave(new Wave(
                    gnatsAvailable, waspsAvailable, beetlesAvailable, wave.TimeToSpawn));
                break;
            }
            WarpGates[i].SpawnWave(new Wave(
                gnats, wasps, beetles, wave.TimeToSpawn));
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnWarpGate", 5, 10);
        InvokeRepeating("SpawnWave", 10, TimeBetweenWaves);
    }

    private void FixedUpdate()
    {
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
        IsAttacking = false;
        Wave newWave = new Wave(WaveNumber, WaveGenerationTime);
        Debug.Log(newWave.Gnats + ", " + newWave.Wasps + ", " + newWave.Beetles);
        DivideWaveBetweenWarpGates(newWave);
        WaveNumber++;
        
        // Invoke waveattack after an amount if time.
        Invoke("WaveAttack", TimeBeforeAttack);
    }

    public void WaveAttack()
    {
        IsAttacking = true;
    }
}
