using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject Green;
    [SerializeField] private GameObject Red;
    [SerializeField] private IdDetector GreenZone;
    [SerializeField] private IdDetector OpenZone;
    
    private void FixedUpdate()
    {
        if (GreenZone.DetectedObjects.Count > 0)
        {
            Red.SetActive(false);
            if (OpenZone.DetectedObjects.Count > 0)
            {
                Green.SetActive(false);
            }
            else
            {
                Green.SetActive(true);
            }
        }
        else
        {
            Red.SetActive(true);
        }
    }
}
