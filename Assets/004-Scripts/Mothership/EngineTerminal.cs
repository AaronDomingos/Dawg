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
    
    private float TempCharge = 0;
    private float TempRepair = 0;
    public float TimeCost = 5;
    public int MateriumCost = 5;
    public float ChargePerCosts = 10;
    public float RepairPerCosts = 10;


    private void FixedUpdate()
    {
        HandleChargeFTL();
        HandleRepairMothership();
    }

    private void HandleChargeFTL()
    {
        TempCharge += FtlEngineers.Count * Time.fixedDeltaTime;
        if (TempCharge >= TimeCost && GameManager.Mothership.Materium >= MateriumCost)
        {
            TempCharge = 0;
            GameManager.Mothership.Materium -= MateriumCost;
            GameManager.Mothership.EngineHealth.Repair(ChargePerCosts);
        }
    }

    private void HandleRepairMothership()
    {
        TempRepair += RepairEngineers.Count * Time.fixedDeltaTime;
        if (TempRepair >= TimeCost && GameManager.Mothership.Materium >= MateriumCost)
        {
            TempRepair = 0;
            GameManager.Mothership.Materium -= MateriumCost;
            GameManager.Mothership.MothershipHealth.Repair(RepairPerCosts);
        }
    }

    private void SetCrewMovement(GameObject crew, bool canMove)
    {
        crew.GetComponent<CrewMovement>().SetCanMove(canMove);
    }

    public void HandleInteraction()
    {
        Activator = interactable.ActiveInteractors.Last();
        SetCrewMovement(Activator, false);
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
