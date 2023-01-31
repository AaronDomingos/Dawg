using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private IdDetector CrashZone;
    [SerializeField] private Health Health;
    [SerializeField] private Size AsteroidSize;
    
    [SerializeField] private Interactable interactable;
    public GameObject Activator = null;
    public List<GameObject> Miners = new List<GameObject>();
    public float MiningPerSec = 1;
    private float Collected = 0;

    private Vector3 Direction = Vector3.zero;
    private float Rotation = 0;
    private float Speed = 0;

    private enum Size
    {
        Large,
        Medium,
        Small
    }
    

    public void Init(Vector3 direction)
    {
        Health.Init(Health.MaxHealth);
        Direction = direction;
        Rotation = Random.Range(-15f, 15f);
        Speed = Random.Range(1f, 5f);

        Activator = null;
        Miners = new List<GameObject>();
    }
    
    
    private void FixedUpdate()
    {
        transform.position += Direction * Speed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.forward * Rotation * Time.fixedDeltaTime);
        CheckBounce();
        HandleMiners();
    }

    private void CheckBounce()
    {
        if (CrashZone.DetectedObjects.Count > 0)
        {
            foreach (GameObject contact in CrashZone.DetectedObjects.ToList())
            {
                Identity id = contact.GetComponent<Identity>();
                if (id.TagsKnownAs.Contains(Identification.Tags.Bounds))
                {
                    Deactivate();
                }
                // Tack in damage if so desired
            }
        }
    }

    public void StartInteract()
    {
        Activator = interactable.ActiveInteractors.Last();
        Activator.GetComponent<DroneMovement>().SetCanMove(false);
        Activator.transform.rotation = Orientation.QuarternionFromAToB(
            Activator.transform, transform.position, 1000);
        Activator.transform.SetParent(transform);
        Activator.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        Miners.Add(Activator);
    }

    private void HandleMiners()
    {
        Collected += Miners.Count * MiningPerSec * Time.fixedDeltaTime;
        if (Collected >= 1)
        {
            Collected = 0;
            ReleaseMaterium(1, 1);
        }
    }

    public void CancelInteract()
    {
        Miners.Remove(Activator);
        Activator.GetComponent<DroneMovement>().SetCanMove(true);
        Activator.transform.SetParent(GameManager.Player.transform);
        Activator.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    
    
    private void ReleaseMaterium(int min, int max)
    {
        int toRelease = Random.Range(min, max + 1);
        for (int i = 0; i < toRelease; i++)
        {
            Vector3 direction = Random.insideUnitCircle.normalized;
            GameObject newMaterium = GameManager.MateriumPool.GetInstance(
                transform.position + (direction * 2),
                Quaternion.Euler(0,0, Random.Range(0f, 360f)));
            if (newMaterium != null)
            {
                newMaterium.GetComponent<Materium>().Init(direction);
            }
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
            if (newAsteroid != null)
            {
                newAsteroid.GetComponent<Asteroid>().Init(Random.insideUnitCircle.normalized);
            }
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
                break;
            case Size.Medium:
                ReleaseMaterium(2, 5);
                ReleaseAsteroid(1, 2);
                break;
            case Size.Small:
                ReleaseMaterium(0, 3);
                break;
        }
        Deactivate();
    }

    private void Deactivate()
    {
        if (transform.Find("Miner") || transform.Find("Miner[Active]"))
        {
            Debug.Log("Asteroid destroyed while player was attached.");
            CancelInteract();
            //BroadcastMessage("OnAsteroidDestroy");
        }
        
        switch (AsteroidSize)
        {
            case Size.Large:
                GameManager.LargeAsteroidPool.Deactivate(gameObject);
                break;
            case Size.Medium:
                GameManager.MediumAsteroidPool.Deactivate(gameObject);
                break;
            case Size.Small:
                GameManager.SmallAsteroidPool.Deactivate(gameObject);
                break;
        }
    }
}
