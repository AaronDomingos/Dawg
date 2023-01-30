using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EngineTerminal : MonoBehaviour
{
    [SerializeField] private Interactable interactable;
    [SerializeField] private Canvas EngineCanvas;

    private bool inMenu = false;
    private GameObject Activator = null;
    
    public List<GameObject> FtlEngineers = new List<GameObject>();
    public List<GameObject> RepairEngineers = new List<GameObject>();
    public float ChargePerSec = 1;
    public float RepairPerSec = 1;


    private void FixedUpdate()
    {
        HandleChargeFTL();
        HandleRepairMothership();
    }

    private void HandleChargeFTL()
    {
        GameManager.Mothership.WarpDrive += 
            ChargePerSec * FtlEngineers.Count * Time.fixedDeltaTime;
    }

    private void HandleRepairMothership()
    {
        GameManager.Mothership.Health +=
            RepairPerSec * RepairEngineers.Count * Time.fixedDeltaTime;
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
                FtlEngineers.Add(Activator);
                break;
            case 1:
                RepairEngineers.Add(Activator);
                break;
        }
        CloseMenu();
    }

    public void CancelInteraction()
    {
        FtlEngineers.Remove(Activator);
        RepairEngineers.Remove(Activator);
        Activator.GetComponent<CrewControl>().sprite.enabled = true;
        SetCrewMovement(Activator, true);
        CloseMenu();
    }

    private void OpenMenu()
    {
        GameManager.Player.CanvasUI.SetActive(false);
        EngineCanvas.gameObject.SetActive(true);
        GameManager.Player.CanToggle = false;
    }

    private void CloseMenu()
    {
        GameManager.Player.CanvasUI.SetActive(true);
        EngineCanvas.gameObject.SetActive(false);
        GameManager.Player.CanToggle = true;
    }
}
