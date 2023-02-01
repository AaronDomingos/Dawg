using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MothershipManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MateriumTxt;
    
    
    
    public float Health;
    public float WarpDrive = 0;
    public float RequiredToJump = 2000;
    public int Materium = 250;
    public int Survivors = 0;

    public int FighterCount = 1;
    public int MinerCount = 1;
    public int SatelliteCount = 1;


    private void FixedUpdate()
    {
        MateriumTxt.text = Convert.ToString(Materium);
    }
}
