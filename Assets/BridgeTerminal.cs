using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BridgeTerminal : MonoBehaviour
{
    [SerializeField] private Interactable interactable;
    [SerializeField] private Canvas BridgeCanvas;

    [SerializeField] public IdDetector DefaultScanner;
    [SerializeField] public IdDetector ShortRangeScanner;
    [SerializeField] public IdDetector MediumRangeScanner;
    [SerializeField] public IdDetector LongRangeScanner;
    
    
    private bool inMenu = false;
    private GameObject Activator = null;
    
    public List<GameObject> MateriumRadarOperators = new List<GameObject>();
    public List<GameObject> EnemyRadarOperators = new List<GameObject>();
    public float ChargePerSec = 1;
    public float RepairPerSec = 1;


    private void FixedUpdate()
    {
        HandlePlayerScans();
        HandleMateriumScans();
        HandleEnemyScans();
    }

    private void HandlePlayerScans()
    {
        
    }
    
    private void HandleMateriumScans()
    {
        
    }

    private void HandleEnemyScans()
    {
        
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
                MateriumRadarOperators.Add(Activator);
                break;
            case 1:
                EnemyRadarOperators.Add(Activator);
                break;
        }
        CloseMenu();
    }

    public void CancelInteraction()
    {
        MateriumRadarOperators.Remove(Activator);
        EnemyRadarOperators.Remove(Activator);
        Activator.GetComponent<CrewControl>().sprite.enabled = true;
        SetCrewMovement(Activator, true);
        CloseMenu();
    }

    private void OpenMenu()
    {
        GameManager.Player.CanvasUI.SetActive(false);
        BridgeCanvas.gameObject.SetActive(true);
        GameManager.Player.CanToggle = false;
    }

    private void CloseMenu()
    {
        GameManager.Player.CanvasUI.SetActive(true);
        BridgeCanvas.gameObject.SetActive(false);
        GameManager.Player.CanToggle = true;
    }

    public void ToggleRadar()
    {
        if (GameManager.Player.RadarUI.activeInHierarchy)
        {
            GameManager.Player.RadarUI.SetActive(false);
            return;
        }
        GameManager.Player.RadarUI.SetActive(true);
    }
}
