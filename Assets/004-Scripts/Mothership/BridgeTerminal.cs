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
    
    public List<GameObject> RadarOperators = new List<GameObject>();


    private void FixedUpdate()
    {
        HandleRadar();
    }

    private void HandleRadar()
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
        OpenMenu();
    }

    public void AwaitResponse(int selection)
    {
        switch (selection)
        {
            case 0:
                RadarOperators.Add(Activator);
                break;
            case 1:
                if (GameManager.Mothership.WarpDrive >= GameManager.Mothership.RequiredToJump)
                {
                    Debug.Log("Handle Win!");
                }
                else
                {
                    Debug.Log("Warp drive is not charged...");
                }
                break;
        }
        CloseMenu();
    }

    public void CancelInteraction()
    {
        RadarOperators.Remove(Activator);
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
