using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DeploymentPod : MonoBehaviour
{

    [SerializeField] private Interactable interactable;

    [SerializeField] private GameObject CrewPrefab;
    [SerializeField] private GameObject FighterPrefab;
    [SerializeField] private GameObject MinerPrefab;
    [SerializeField] private GameObject SatellitePrefab;
    
    [SerializeField] private Transform DroneSpawn;
    [SerializeField] private Transform CrewSpawn;

    public DroneType DronePodType;
    
    public enum DroneType
    {
        Fighter,
        Miner,
        Satellite
    }
    
    public void OnInteract()
    {
        GameObject interactor = interactable.ActiveInteractors.Last();
        Identity identity = interactor.GetComponent<Identity>();

        Debug.Log("Drone Bay interaction");
        if (identity.TagsKnownAs.Contains(Identification.Tags.Crew))
        {
            GameObject newDrone;
            if (DronePodType == DroneType.Fighter &&
                GameManager.Mothership.FighterCount > 0)
            {
                newDrone = Instantiate(FighterPrefab, DroneSpawn.position, DroneSpawn.rotation);
                GameManager.Mothership.FighterCount--;
            }

            else if (DronePodType == DroneType.Miner &&
                GameManager.Mothership.MinerCount > 0)
            {
                newDrone = Instantiate(MinerPrefab, DroneSpawn.position, DroneSpawn.rotation);
                GameManager.Mothership.MinerCount--;
            }
            
            else if (DronePodType == DroneType.Satellite &&
                     GameManager.Mothership.SatelliteCount > 0)
            {
                newDrone = Instantiate(SatellitePrefab, DroneSpawn.position, DroneSpawn.rotation);
                GameManager.Mothership.SatelliteCount--;
            }
            else
            {
                interactable.Cancel(interactor);
                return;
            }
            Debug.Log("Deploying Drone!");
            newDrone.GetComponent<DroneMovement>().SetMomentum(
                Proximity.DirectionToObject(gameObject, DroneSpawn.gameObject), 1f);
            newDrone.GetComponent<DroneControl>().SetDroneColor(
                interactor.GetComponent<CrewControl>().CrewColor);
            
            interactable.Cancel(interactor);
            GameManager.Player.ReplaceOldWithNew(interactor, newDrone);
            return;
        }

        if (identity.TagsKnownAs.Contains(Identification.Tags.Drone))
        {
            Debug.Log("Welcome aboard, Captain!");
            GameObject newCrew = Instantiate(CrewPrefab, CrewSpawn.position, CrewSpawn.rotation);
            newCrew.transform.position = CrewSpawn.position;
            newCrew.GetComponent<CrewControl>().SetColor(
                interactor.GetComponent<DroneControl>().DroneColor);

            if (identity.TagsKnownAs.Contains(Identification.Tags.Fighter))
            {
                GameManager.Mothership.FighterCount++;
            }
            else if (identity.TagsKnownAs.Contains(Identification.Tags.Mining))
            {
                GameManager.Mothership.MinerCount++;
            }
            else if (identity.TagsKnownAs.Contains(Identification.Tags.Satelite))
            {
                GameManager.Mothership.SatelliteCount++;
            }
            Debug.Log(interactor.name);
            interactable.Cancel(interactor);
            GameManager.Player.ReplaceOldWithNew(interactor, newCrew);
            return;
        }
        Debug.Log("Interactor is neither Crew or Drone");
        interactable.Cancel(interactor);
    }
}
