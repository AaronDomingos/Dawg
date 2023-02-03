using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class MothershipManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MateriumTxt;
    [SerializeField] private TextMeshProUGUI SurvivorTxt;

    [SerializeField] private UnityEngine.UI.Slider HealthSlider;
    [SerializeField] private UnityEngine.UI.Slider EngineSlider;

    
    public Health MothershipHealth;
    public Health EngineHealth;
    
    public float InitHealth = 500;
    public float InitEngine = 500;
    
    public float RequiredToJump = 2000;
    public int Materium = 250;
    public int Survivors = 0;

    public int FighterCount = 1;
    public int MinerCount = 1;
    public int SatelliteCount = 1;


    private void Start()
    {
        MothershipHealth.Init(InitHealth);
        HealthSlider.maxValue = MothershipHealth.MaxHealth;
        
        EngineHealth.Init(InitEngine);
        EngineSlider.maxValue = EngineHealth.MaxHealth;
        EngineHealth.Damage(InitEngine);
    }
    
    
    private void FixedUpdate()
    {
        MateriumTxt.text = Convert.ToString(Materium);
        SurvivorTxt.text = Convert.ToString(Survivors);

        HealthSlider.value = MothershipHealth.CurrentHealth;
        EngineSlider.value = EngineHealth.CurrentHealth;
    }
}
