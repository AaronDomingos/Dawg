using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    public SpriteRenderer MySprite;
    public SpriteRenderer TargetSprite;

    public int MaxAsteroidsToPopulate = 20;
    public SpawnWeights spawnWeights = new SpawnWeights(10, 4, 1);

    [Serializable]
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
        InvokeRepeating("TrySpawn", 1, 5);
    }


    private Vector3 PointInBounds(Renderer target)
    {
        float maxX = target.bounds.size.x * .5f;
        float maxY = target.bounds.size.y * .5f;

        return new Vector3(
            Random.Range(-maxX, maxX),
            Random.Range(-maxY, maxY));
    }


    private void TrySpawn()
    {
        if (GameManager.SmallAsteroidPool.EnabledObjects.Count +
            GameManager.MediumAsteroidPool.EnabledObjects.Count +
            GameManager.LargeAsteroidPool.EnabledObjects.Count < MaxAsteroidsToPopulate)
        {
            SpawnRandom();
        }
    }
    

    public void SpawnRandom()
    {
        int randomEnemy = Random.Range(1, spawnWeights.Total);
        Vector3 start = PointInBounds(MySprite) + transform.position;
        Vector3 finish = PointInBounds(TargetSprite);
        Vector3 directionTo = Orientation.DirectionToVector(start, finish);
        start += directionTo * 25;

        GameObject newAsteroid = null;
        if (randomEnemy < spawnWeights.Small)
        {
            newAsteroid = GameManager.SmallAsteroidPool.GetInstance(start, transform.rotation);
        }
        else if (randomEnemy < spawnWeights.Small + spawnWeights.Medium)
        {
            newAsteroid = GameManager.MediumAsteroidPool.GetInstance(start, transform.rotation);
        }
        else
        {
            newAsteroid = GameManager.LargeAsteroidPool.GetInstance(start, transform.rotation);
        }

        if (newAsteroid != null)
        {
            newAsteroid.GetComponent<Asteroid>().Init(directionTo);
        }
    }
}
