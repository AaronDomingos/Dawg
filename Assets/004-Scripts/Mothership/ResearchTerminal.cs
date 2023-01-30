using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResearchTerminal : MonoBehaviour
{
    [SerializeField] private Interactable interactable;
    [SerializeField] private Canvas ResearchCanvas;

    private bool inMenu = false;
    private GameObject Activator = null;
    
    public List<GameObject> CloneResearchers = new List<GameObject>();
    public List<GameObject> TechResearchers = new List<GameObject>();
    public float CloneResearchAmount = 0;
    public float TechResearchAmount = 0;
    public float ResearchPerSec = 5;

    

    private void FixedUpdate()
    {
        HandleCloneResearch();
        HandleTechResearch();
    }

    private void HandleCloneResearch()
    {
        CloneResearchAmount += ResearchPerSec * CloneResearchers.Count * Time.fixedDeltaTime;
    }

    private void HandleTechResearch()
    {
        TechResearchAmount += ResearchPerSec * TechResearchers.Count * Time.fixedDeltaTime;
    }

    private void SetCrewMovement(GameObject crew, bool canMove)
    {
        crew.GetComponent<CrewMovement>().SetCanMove(canMove);
    }

    public void HandleInteraction()
    {
        
        Activator = interactable.ActiveInteractors.Last();
        Debug.Log(Activator.name);

        //Activator.GetComponent<CrewControl>().sprite.enabled = false;
        SetCrewMovement(Activator, false);
        OpenMenu();
    }

    public void AwaitResponse(int selection)
    {
        switch (selection)
        {
            case 0:
                CloneResearchers.Add(Activator);
                break;
            case 1:
                TechResearchers.Add(Activator);
                break;
        }
        CloseMenu();
    }

    public void CancelInteraction()
    {
        CloneResearchers.Remove(Activator);
        TechResearchers.Remove(Activator);
        //Activator.GetComponent<CrewControl>().sprite.enabled = true;
        SetCrewMovement(Activator, true);
        CloseMenu();
    }

    private void OpenMenu()
    {
        GameManager.Player.CanvasUI.SetActive(false);
        ResearchCanvas.gameObject.SetActive(true);
        GameManager.Player.CanToggle = false;
    }

    private void CloseMenu()
    {
        GameManager.Player.CanvasUI.SetActive(true);
        ResearchCanvas.gameObject.SetActive(false);
        GameManager.Player.CanToggle = true;
    }
}
