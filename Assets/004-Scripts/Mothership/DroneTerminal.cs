using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DroneTerminal : MonoBehaviour
{
    [SerializeField] private Interactable interactable;
    [SerializeField] private Canvas DroneBayCanvas;

    private bool inMenu = false;
    private GameObject Activator = null;


    public int FighterCount = 1;
    public float FighterCost = 240;
    public float FighterProgress = 0;
    public List<GameObject> FighterBuilders = new List<GameObject>();

    public int MinerCount = 1;
    public float MinerCost = 240;
    public float MinerProgress = 0;
    public List<GameObject> MinerBuilders = new List<GameObject>();

    public int SatelliteCount = 1;
    public float SatelliteCost = 240;
    public float SatelliteProgress = 0;
    public List<GameObject> SatelliteBuilders = new List<GameObject>();

    public float BuildPerSec = 1;


    private void FixedUpdate()
    {
        HandleBuilding();
    }

    private void HandleBuilding()
    {
        FighterProgress += BuildPerSec * FighterBuilders.Count * Time.fixedDeltaTime;
        if (FighterProgress >= FighterCost) { FighterCount++; FighterProgress = 0; }

        MinerProgress += BuildPerSec * MinerBuilders.Count * Time.fixedDeltaTime;
        if (MinerProgress >= MinerCost) { MinerCount++; MinerProgress = 0; }

        SatelliteProgress += BuildPerSec * SatelliteBuilders.Count * Time.fixedDeltaTime;
        if (SatelliteProgress >= SatelliteCost) { SatelliteCount++; SatelliteProgress = 0; }
    }


    private void SetCrewMovement(GameObject crew, bool canMove)
    {
        crew.GetComponent<CrewMovement>().SetCanMove(canMove);
    }

    public void HandleInteraction()
    {
        Activator = interactable.ActiveInteractors.Last();
        SetCrewMovement(Activator, false);
        
        Activator.GetComponent<CrewControl>().sprite.enabled = false;
        OpenMenu();
    }

    public void AwaitResponse(int selection)
    {
        switch (selection)
        {
            case 0:
                FighterBuilders.Add(Activator);
                break;
            case 1:
                MinerBuilders.Add(Activator);
                break;
            case 2:
                SatelliteBuilders.Add(Activator);
                break;
        }
        CloseMenu();
    }

    public void CancelInteraction()
    {
        FighterBuilders.Remove(Activator);
        MinerBuilders.Remove(Activator);
        SatelliteBuilders.Remove(Activator);
        Activator.GetComponent<CrewControl>().sprite.enabled = true;
        SetCrewMovement(Activator, true);
        CloseMenu();
    }

    private void OpenMenu()
    {
        GameManager.Player.CanvasUI.SetActive(false);
        DroneBayCanvas.gameObject.SetActive(true);
        GameManager.Player.CanToggle = false;
    }

    private void CloseMenu()
    {
        GameManager.Player.CanvasUI.SetActive(true);
        DroneBayCanvas.gameObject.SetActive(false);
        GameManager.Player.CanToggle = true;
    }
}
