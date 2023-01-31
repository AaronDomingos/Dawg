using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CloneTerminal : MonoBehaviour
{
    [SerializeField] private GameObject CrewPrefab;
    [SerializeField] private List<Transform> ClonePods = new List<Transform>();
    [SerializeField] private Interactable interactable;
    [SerializeField] private GameObject CloneUI;
    
    public int Cost = 50;

    public GameObject Activator;
    private Color SelectedColor = Color.white;
    [SerializeField] private Image CloneIcon;
    [SerializeField] private Image RedIcon;
    [SerializeField] private Image BlueIcon;
    [SerializeField] private Image GreenIcon;
    [SerializeField] private Image PurpleIcon;
    [SerializeField] private Image OrangeIcon;
    [SerializeField] private Image CyanIcon;
    [SerializeField] private Image PinkIcon;
    [SerializeField] private Image YellowIcon;
    [SerializeField] private Image WhiteIcon;
    [SerializeField] private Image BlackIcon;



    public void TryCreateClone()
    {
        if (GameManager.Mothership.Materium >= Cost)
        {
            GameObject interactor = interactable.ActiveInteractors.Last();
            if (GameManager.Player.hasEmptyPlayables())
            {
                GameManager.Mothership.Materium -= Cost;
                int index = GameManager.Player.FirstAvailableIndex();
                GameObject newCrew = Instantiate(CrewPrefab, 
                    ClonePods[index].position, Quaternion.identity);
                GameManager.Player.AddPlayable(newCrew);
                GameManager.Player.GoToPlayableIndex(index);
                GameManager.Player.ActivePlayable.GetComponent<CrewControl>().SetColor(CloneIcon.color);
                interactable.Cancel(interactor);
                return;
            }
            Debug.Log("No available crew slots");
            return;
        }
        Debug.Log("Not enough materium");
    }

    public void OnInteract()
    {
        Activator = interactable.ActiveInteractors.Last();
        Activator.GetComponent<CrewMovement>().SetCanMove(false);
        OpenMenu();
    }


    public void OnCancel()
    {
        Activator.GetComponent<CrewMovement>().SetCanMove(true);
        CloseMenu();
    }

    private void OpenMenu()
    {
        //GameManager.Player.CanvasUI.SetActive(false);
        CloneUI.gameObject.SetActive(true);
        GameManager.Player.CanToggle = false;
    }

    private void CloseMenu()
    {
        //GameManager.Player.CanvasUI.SetActive(true);
        CloneUI.gameObject.SetActive(false);
        GameManager.Player.CanToggle = true;
    }

    public void ChangeColor(int color)
    {
        switch (color)
        {
            case 0: //Red
                SelectedColor = RedIcon.color;
                break;
            case 1: //Blue
                SelectedColor = BlueIcon.color;
                break;
            case 2: //Green
                SelectedColor = GreenIcon.color;
                break;
            case 3: //Purple
                SelectedColor = PurpleIcon.color;
                break;
            case 4: //Orange
                SelectedColor = OrangeIcon.color;
                break;
            case 5: //Cyan
                SelectedColor = CyanIcon.color;
                break;
            case 6: //Pink
                SelectedColor = PinkIcon.color;
                break;
            case 7: //Yellow
                SelectedColor = YellowIcon.color;
                break;
            case 8: //White
                SelectedColor = WhiteIcon.color;
                break;
            case 9: //Black
                SelectedColor = BlackIcon.color;
                break;
        }
        CloneIcon.color = SelectedColor;
    }
}
