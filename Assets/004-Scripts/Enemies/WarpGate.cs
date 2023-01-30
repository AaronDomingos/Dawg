using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WarpGate : MonoBehaviour
{


    public SpawnWeights spawnWeights = new SpawnWeights(10, 4, 1);

    public class SpawnWeights
    {
        public int GnatWeight;
        public int WaspWeight;
        public int BeetleWeight;
        public int Total;

        public SpawnWeights(int gnat, int wasp, int beetle)
        {
            GnatWeight = gnat;
            WaspWeight = wasp;
            BeetleWeight = beetle;
            Total = gnat + wasp + beetle;
        }
    }
    
    private void Start()
    {
        InvokeRepeating("SpawnRandom", 1, 5);
    }


    public void SpawnRandom()
    {
        int randomEnemy = Random.Range(1, spawnWeights.Total);

        if (randomEnemy < spawnWeights.GnatWeight)
        {
            SpawnGnat();
            return;
        }
        if (randomEnemy < spawnWeights.GnatWeight + spawnWeights.WaspWeight)
        {
            SpawnWasp();
            return;
        }
        SpawnBeetle();
    }

    private void SpawnGnat()
    {
        GameObject newGnat = Hivemind.GnatPool.GetInstance(
            transform.position, transform.rotation);
        if (newGnat != null)
        {
            newGnat.GetComponent<Gnat>().Init();
        }
    }

    private void SpawnWasp()
    {
        GameObject newWasp = Hivemind.WaspPool.GetInstance(
            transform.position, transform.rotation);
        if (newWasp != null)
        {
            newWasp.GetComponent<Wasp>().Init();
        }
    }

    private void SpawnBeetle()
    {
        GameObject newBeetle = Hivemind.BeetlePool.GetInstance(
            transform.position, transform.rotation);
        if (newBeetle != null)
        {
            newBeetle.GetComponent<Beetle>().Init();
        }
    }
}
