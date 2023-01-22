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

    public void SetOnboard()
    {
        Debug.Log("Going On Board");
        isCrewActive = true;
        isDroneActive = false;
        
        player.crew.gameObject.SetActive(true);
        player.drone.gameObject.SetActive(false);
        
        player.camera.RemoveAllCameraTargets();
        player.camera.AddCameraTarget(player.crew.transform);
    }

    // Maybe pass it the drone component it'll be using?
    public void SetOffBoard()
    {
        Debug.Log("Going Off Board");
        isDroneActive = true;
        isCrewActive = false;
        
        player.drone.gameObject.SetActive(true);
        player.crew.gameObject.SetActive(false);
        
        player.camera.RemoveAllCameraTargets();
        player.camera.AddCameraTarget(player.drone.transform);
    }
}
