using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private Player player;
    
    public bool isUserActive { get; private set; } = false;
    public bool isCrewActive { get; private set; } = false;
    public bool isDroneActive { get; private set; } = false;
    
    // isChatting
    // isGuidingMissile
    // isInteracting

    public void DisableUser()
    {
        isUserActive = false;
    }

    public void EnableUser()
    {
        isUserActive = true;
    }
}
