using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrewInputHandler : InputHandler
{
    public override string Name 
    { get { return "Crew"; } }
    
    private UserInput userInput;
    [SerializeField] private CrewControl crew;

    private void Awake()
    {
        userInput = new UserInput();
    }
    private void OnEnable()
    {
        userInput.Enable();
    }

    private void OnDisable()
    {
        userInput.Disable();
    }
    
    public void Handle()
    {
        crew.ApplyWalk(userInput.Crew.Walk.ReadValue<Vector2>());
    }
}
