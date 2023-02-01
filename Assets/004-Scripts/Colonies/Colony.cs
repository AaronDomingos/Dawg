using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Colony : MonoBehaviour
{
    [SerializeField] private Health Health;
    [SerializeField] private GameObject SurvivorPrefab;
    
    [SerializeField] private Interactable interactable;
    public GameObject Activator = null;
    public List<GameObject> Rescuers = new List<GameObject>();
    public float RescuePerSec = 1;
    private float Rescued = 0;

    public int SurvivorsLeft = 50;
    public int TotalSurvivors = 50;
    
    private void FixedUpdate()
    {
        if (SurvivorsLeft > 0)
        {
            HandleRescuers();
        }
    }

    public void StartInteract()
    {
        Activator = interactable.ActiveInteractors.Last();
        Activator.GetComponent<DroneMovement>().SetCanMove(false);
        Activator.transform.rotation = Orientation.QuarternionFromAToB(
            Activator.transform, transform.position, 1000);
        Activator.GetComponent<Satellite>().AbductionLight.SetActive(true);
        
        Activator.transform.SetParent(transform);
        Activator.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        
        Rescuers.Add(Activator);
    }

    private void HandleRescuers()
    {
        Rescued += Rescuers.Count * RescuePerSec * Time.fixedDeltaTime;
        if (Rescued >= 1)
        {
            Rescued = 0;
            SurvivorsLeft--;
            ReleaseSurvivors();
        }
    }

    public void CancelInteract()
    {
        Rescuers.Remove(Activator);
        Activator.GetComponent<DroneMovement>().SetCanMove(true);
        Activator.GetComponent<Satellite>().AbductionLight.SetActive(false);
        
        Activator.transform.SetParent(GameManager.Player.transform);
        Activator.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void ReleaseSurvivors()
    {
        Vector3 directionTo = Proximity.DirectionToObject(gameObject, Activator);
        GameObject newSurvivor = Instantiate(SurvivorPrefab, 
            transform.position + (directionTo * 2), Quaternion.identity);
        
        if (newSurvivor != null)
        {
            newSurvivor.GetComponent<Survivor>().Init(directionTo);
        }
    }
}
