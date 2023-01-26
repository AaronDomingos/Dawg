using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DroneBay : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private Interactable interactable;
    [SerializeField] private GameObject DronePrefab;
    [SerializeField] private GameObject CrewPrefab;
    [SerializeField] private Transform DroneSpawn;
    [SerializeField] private Transform CrewSpawn;

    public void OnInteract()
    {
        GameObject interactor = interactable.ActiveInteractors.Last();
        Identity identity = interactor.GetComponent<Identity>();

        if (identity.TagsKnownAs.Contains(Identification.Tags.Crew))
        {
            Debug.Log("Deploying Drone!");
            GameObject newDrone = Instantiate(DronePrefab, DroneSpawn.position, Quaternion.identity);
            newDrone.GetComponent<DroneMovement>().SetMomentum(
                Proximity.DirectionToObject(gameObject, DroneSpawn.gameObject), 1f);
            player.ReplaceOldWithNew(interactor, newDrone);
            interactable.Cancel(interactor);
            return;
        }

        if (identity.TagsKnownAs.Contains(Identification.Tags.Drone))
        {
            Debug.Log("Welcome aboard, Captain!");
            GameObject newCrew = Instantiate(CrewPrefab, CrewSpawn.position, Quaternion.identity);
            player.ReplaceOldWithNew(interactor, newCrew);
            interactable.Cancel(interactor);
            return;
        }
        
        Debug.Log("Interactor is neither Crew or Drone");
        interactable.Cancel(interactor);
    }
}
