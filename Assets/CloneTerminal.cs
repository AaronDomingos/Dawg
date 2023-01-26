using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class CloneTerminal : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject CrewPrefab;
    [SerializeField] private List<Transform> ClonePods = new List<Transform>();

    [SerializeField] private Interactable interactable;



    public void OnInteract()
    {
        GameObject interactor = interactable.ActiveInteractors.Last();
        if (player.hasEmptyPlayables())
        {
            int index = player.FirstAvailableIndex();
            GameObject newCrew = Instantiate(CrewPrefab, 
                ClonePods[Random.Range(0, 12)].position, Quaternion.identity);
            player.AddPlayable(newCrew);
            player.GoToPlayableIndex(index);
            interactable.Cancel(interactor);
            return;
        }
        Debug.Log("No available playable slots");
        interactable.Cancel(interactor);
    }
}
