using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DeploymentPod : MonoBehaviour
{

    [SerializeField] private Interactable interactable;

    [SerializeField] private DroneTerminal MyDroneBay;
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

        if (identity.TagsKnownAs.Contains(Identification.Tags.Crew))
        {
            GameObject newDrone;
            if (DronePodType == DroneType.Fighter &&
                MyDroneBay.FighterCount > 0)
            {
                newDrone = Instantiate(FighterPrefab, DroneSpawn.position, DroneSpawn.rotation);
                MyDroneBay.FighterCount--;
            }

            else if (DronePodType == DroneType.Miner &&
                MyDroneBay.MinerCount > 0)
            {
                newDrone = Instantiate(MinerPrefab, DroneSpawn.position, DroneSpawn.rotation);
                MyDroneBay.MinerCount--;
            }
            
            else if (DronePodType == DroneType.Satellite &&
                     MyDroneBay.SatelliteCount > 0)
            {
                newDrone = Instantiate(SatellitePrefab, DroneSpawn.position, DroneSpawn.rotation);
                MyDroneBay.SatelliteCount--;
            }
            else
            {
                interactable.Cancel(interactor);
                return;
            }
            Debug.Log("Deploying Drone!");
            newDrone.GetComponent<DroneControl>().Pilot = interactor;
            newDrone.GetComponent<DroneMovement>().SetMomentum(
                Proximity.DirectionToObject(gameObject, DroneSpawn.gameObject), 1f);
            GameManager.Player.ReplaceOldWithNew(interactor, newDrone);
            interactable.Cancel(interactor);
            return;
        }

        if (identity.TagsKnownAs.Contains(Identification.Tags.Drone))
        {
            Debug.Log("Welcome aboard, Captain!");
            GameObject dronePilot = interactor.GetComponent<DroneControl>().Pilot;
            GameManager.Player.ReplaceOldWithNew(interactor, dronePilot);
            dronePilot.transform.position = CrewSpawn.position;

            if (identity.TagsKnownAs.Contains(Identification.Tags.Fighter))
            {
                MyDroneBay.FighterCount++;
            }
            else if (identity.TagsKnownAs.Contains(Identification.Tags.Mining))
            {
                MyDroneBay.MinerCount++;
            }
            else if (identity.TagsKnownAs.Contains(Identification.Tags.Satelite))
            {
                MyDroneBay.SatelliteCount++;
            }
            Destroy(interactor);
            return;
        }
        Debug.Log("Interactor is neither Crew or Drone");
        interactable.Cancel(interactor);
    }
}
