using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class DroneTerminal : MonoBehaviour
{
    [SerializeField] private Interactable interactable;
    [SerializeField] private Canvas DroneBayCanvas;
    
    [SerializeField] private TextMeshProUGUI FighterTxt;
    [SerializeField] private TextMeshProUGUI FighterCostTxt;
    [SerializeField] private TextMeshProUGUI MinerTxt;
    [SerializeField] private TextMeshProUGUI MinerCostTxt;
    [SerializeField] private TextMeshProUGUI SatelliteTxt;
    [SerializeField] private TextMeshProUGUI SatelliteCostTxt;

    private bool inMenu = false;
    private GameObject Activator = null;
    
    public int FighterCost = 250;
    public int MinerCost = 0;
    public int SatelliteCost = 100;


    private void FixedUpdate()
    {
        FighterTxt.text = Convert.ToString(GameManager.Mothership.FighterCount);
        FighterCostTxt.color = (GameManager.Mothership.Materium < FighterCost) ? Color.red : Color.white;

        MinerTxt.text = Convert.ToString(GameManager.Mothership.MinerCount);
        MinerCostTxt.color = (GameManager.Mothership.Materium < MinerCost) ? Color.red : Color.white;
        
        SatelliteTxt.text = Convert.ToString(GameManager.Mothership.SatelliteCount);
        SatelliteCostTxt.color = (GameManager.Mothership.Materium < SatelliteCost) ? Color.red : Color.white;
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
        if (Activator != null && Activator == GameManager.Player.ActivePlayable)
        {
            switch (selection)
            {
                case 0:
                    if (GameManager.Mothership.Materium >= FighterCost)
                    {
                        GameManager.Mothership.FighterCount++;
                        GameManager.Mothership.Materium -= FighterCost;
                    }
                    break;
                case 1:
                    if (GameManager.Mothership.Materium >= MinerCost)
                    {
                        GameManager.Mothership.MinerCount++;
                        GameManager.Mothership.Materium -= MinerCost;
                    }
                    break;
                case 2:
                    if (GameManager.Mothership.Materium >= SatelliteCost)
                    {
                        GameManager.Mothership.SatelliteCount++;
                        GameManager.Mothership.Materium -= SatelliteCost;
                    }
                    break;
            }
        }
    }

    public void CancelInteraction()
    {
        SetCrewMovement(Activator, true);
        CloseMenu();
        Activator = null;
    }

    private void OpenMenu()
    {
        DroneBayCanvas.gameObject.SetActive(true);
        GameManager.Player.CanToggle = false;
    }

    private void CloseMenu()
    {
        DroneBayCanvas.gameObject.SetActive(false);
        GameManager.Player.CanToggle = true;
    }
}
