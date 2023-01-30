using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    
    public SpawnWeights spawnWeights = new SpawnWeights(10, 4, 1);

    public class SpawnWeights
    {
        public int Small;
        public int Medium;
        public int Large;
        public int Total;

        public SpawnWeights(int small, int medium, int large)
        {
            Small = small;
            Medium = medium;
            Large = large;
            Total = small + medium + large;
        }
    }
    
    private void Start()
    {
        InvokeRepeating("SpawnRandom", 1, 5);
    }


    public void SpawnRandom()
    {
        int randomEnemy = Random.Range(1, spawnWeights.Total);

        if (randomEnemy < spawnWeights.Small)
        {
            SpawnSmall();
            return;
        }
        if (randomEnemy < spawnWeights.Small + spawnWeights.Medium)
        {
            SpawnMedium();
            return;
        }
        SpawnLarge();
    }

    private void SpawnSmall()
    {
        GameObject newAsteroid = GameManager.SmallAsteroidPool.GetInstance(
            transform.position, transform.rotation);
        if (newAsteroid != null)
        {
            newAsteroid.GetComponent<Asteroid>().Init();
        }
    }

    private void SpawnMedium()
    {
        GameObject newAsteroid = GameManager.MediumAsteroidPool.GetInstance(
            transform.position, transform.rotation);
        if (newAsteroid != null)
        {
            newAsteroid.GetComponent<Asteroid>().Init();
        }
    }

    private void SpawnLarge()
    {
        GameObject newAsteroid = GameManager.LargeAsteroidPool.GetInstance(
            transform.position, transform.rotation);
        if (newAsteroid != null)
        {
            newAsteroid.GetComponent<Beetle>().Init();
        }
    }
}
