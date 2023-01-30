using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{

    [SerializeField] private Health Health;

    [SerializeField] private Size AsteroidSize;

    private enum Size
    {
        Large,
        Medium,
        Small
    }
    

    public void Init()
    {
        // Create a bezier curve to the edge of the map.
        // Rotate, yada yada
        // Set Health
        
    }
    
    
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * -10 * Time.fixedDeltaTime);
    }


    
    
    private void ReleaseMaterium(int min, int max)
    {
        int toRelease = Random.Range(min, max + 1);
        for (int i = 0; i < toRelease; i++)
        {
            GameObject newMaterium = GameManager.MateriumPool.GetInstance(
                transform.position, Quaternion.Euler(0,0, Random.Range(0f, 360f)));
            newMaterium.GetComponent<Materium>().Init();
        }
    }

    private void ReleaseAsteroid(int min, int max)
    {
        int toRelease = Random.Range(min, max + 1);
        for (int i = 0; i < toRelease; i++)
        {
            GameObject newAsteroid;
            if (AsteroidSize == Size.Large)
            {
                newAsteroid = GameManager.MediumAsteroidPool.GetInstance(
                    transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            }
            newAsteroid = GameManager.SmallAsteroidPool.GetInstance(
                transform.position, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            newAsteroid.GetComponent<Asteroid>().Init();
        }
    }
    private void OnDamaged()
    {
        ReleaseMaterium(0, 1);
    }

    private void OnStatusDestroy()
    {
        // If it's hosting a wasp
        if (transform.Find("Wasp"))
        {
            BroadcastMessage("OnAsteroidDestroyed");
        }

        switch (AsteroidSize)
        {
            case Size.Large:
                ReleaseMaterium(4, 8);
                ReleaseAsteroid(1, 3);
                GameManager.LargeAsteroidPool.Deactivate(gameObject);
                break;
            case Size.Medium:
                ReleaseMaterium(2, 5);
                ReleaseAsteroid(1, 2);
                GameManager.MediumAsteroidPool.Deactivate(gameObject);
                break;
            case Size.Small:
                ReleaseMaterium(0, 3);
                GameManager.SmallAsteroidPool.Deactivate(gameObject);
                break;
        }
    }
}
