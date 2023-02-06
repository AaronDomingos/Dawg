using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WarpGate : MonoBehaviour
{

    public Swarm SpawningSwarm;
    

    private void Start()
    {
        //StartSpawningWaves();
    }

    public void Init(Swarm spawningSwarm)
    {
        transform.rotation = Orientation.QuarternionFromAToB(
            transform, Vector3.zero, 1000f);

        SpawningSwarm = spawningSwarm;
    }

    public void StartSpawningWaves()
    {
        //InvokeRepeating("SpawnNextWave", 5f, 5f);
    }

    public void SpawnWave(Swarm.Wave wave)
    {
        Debug.Log("Spawning new wave!");
        Debug.Log(wave.Gnats + ", " + wave.Wasps + ", " + wave.Beetles);
        if (Hivemind.GnatPool.EnabledObjects.Count + wave.Gnats < Hivemind.GnatPool.MaxQuantity)
        {
            for (int i = 0; i < wave.Gnats; i++)
            {
                Invoke("SpawnGnat",
                    (Convert.ToSingle(i) / Convert.ToSingle(wave.Gnats)) * wave.TimeToSpawn);
            }
        }
        if (Hivemind.WaspPool.EnabledObjects.Count + wave.Wasps < Hivemind.WaspPool.MaxQuantity)
        {
            for (int i = 0; i < wave.Wasps; i++)
            {
                Invoke("SpawnWasp",
                    (Convert.ToSingle(i) / Convert.ToSingle(wave.Wasps)) * wave.TimeToSpawn);
            }
        }
        if (Hivemind.BeetlePool.EnabledObjects.Count + wave.Beetles < Hivemind.BeetlePool.MaxQuantity)
        {
            for (int i = 0; i < wave.Beetles; i++)
            {
                Invoke("SpawnBeetle",
                    (Convert.ToSingle(i) / Convert.ToSingle(wave.Beetles)) * wave.TimeToSpawn);
            }
        }
    }

    private void SpawnGnat()
    {
        GameObject newGnat = Hivemind.GnatPool.GetInstance(
            transform.position, transform.rotation);
        if (newGnat != null)
        {
            newGnat.GetComponent<Gnat>().Init(SpawningSwarm);
        }
    }

    private void SpawnWasp()
    {
        GameObject newWasp = Hivemind.WaspPool.GetInstance(
            transform.position, transform.rotation);
        if (newWasp != null)
        {
            newWasp.GetComponent<Wasp>().Init(SpawningSwarm);
        }
    }

    private void SpawnBeetle()
    {
        GameObject newBeetle = Hivemind.BeetlePool.GetInstance(
            transform.position, transform.rotation);
        if (newBeetle != null)
        {
            newBeetle.GetComponent<Beetle>().Init(SpawningSwarm);
        }
    }

    private void Deactivate()
    {
        CancelInvoke();   
    }
}
