using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public bool isUserActive { get; private set; } = false;
    public bool isCharacterActive { get; private set; } = false;
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

    public void SetOnboard()
    {
        Debug.Log("Going On Board");
        isCharacterActive = true;
        isDroneActive = false;
    }

    // Maybe pass it the drone component it'll be using?
    public void SetOffBoard()
    {
        Debug.Log("Going Off Board");
        isDroneActive = true;
        isCharacterActive = false;
    }
    
}
