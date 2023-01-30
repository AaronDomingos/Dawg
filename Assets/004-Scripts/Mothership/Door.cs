using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private IdDetector detector;
    
    private void FixedUpdate()
    {
        if (detector.DetectedObjects.Count > 0)
        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }
    }
}
