using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class CloneTerminal : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private GameObject CrewPrefab;
    [SerializeField] private List<Transform> ClonePods = new List<Transform>();

    [SerializeField] private Interactable interactable;



    public void OnInteract()
    {
        GameObject interactor = interactable.ActiveInteractors.Last();
        if (playerManager.hasEmptyPlayables())
        {
            int index = playerManager.FirstAvailableIndex();
            GameObject newCrew = Instantiate(CrewPrefab, 
                ClonePods[Random.Range(0, 12)].position, Quaternion.identity);
            playerManager.AddPlayable(newCrew);
            playerManager.GoToPlayableIndex(index);
            interactable.Cancel(interactor);
            return;
        }
        Debug.Log("No available playable slots");
        interactable.Cancel(interactor);
    }
}
