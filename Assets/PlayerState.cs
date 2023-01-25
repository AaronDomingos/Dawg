using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerState : NetworkBehaviour
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

    [Command(requiresAuthority = false)]
    public void CmdSetOnBoard()
    {
        RpcSetOnboard();
    }
    
    [ClientRpc]
    public void RpcSetOnboard()
    {
        Debug.Log("Going On Board");
        isCrewActive = true;
        isDroneActive = false;
        
        player.crew.gameObject.SetActive(true);
        player.drone.gameObject.SetActive(false);
        
        player.camera.RemoveAllCameraTargets();
        player.camera.AddCameraTarget(player.crew.transform);
    }

    [Command]
    public void CmdSetOffBoard()
    {
        RpcSetOffBoard();
    }

    // Maybe pass it the drone component it'll be using?
    [ClientRpc]
    public void RpcSetOffBoard()
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
