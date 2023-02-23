using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    public GameObject PauseCanvas;


    public void TogglePauseCanvas()
    {
        if (PauseCanvas.activeInHierarchy)
        {
            PauseCanvas.SetActive(false);
            return;
        }
        PauseCanvas.SetActive(true);
    }
}
