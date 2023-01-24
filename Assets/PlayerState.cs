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

    public void SetOnBoard()
    {
        Debug.Log("Going On Board");
        isCrewActive = true;
        isDroneActive = false;
        player.camera.RemoveAllCameraTargets();
        player.camera.AddCameraTarget(player.crew.transform);
        CmdSetOnBoard();
    }
    
    [Command]
    public void CmdSetOnBoard()
    {
        RpcSetOnboard();
    }
    
    [ClientRpc]
    public void RpcSetOnboard()
    {
        Debug.Log("Toggle Rpc Received");
        player.crew.gameObject.SetActive(true);
        player.drone.gameObject.SetActive(false);
    }

    public void SetOffBoard()
    {
        Debug.Log("Going Off Board");
        isDroneActive = true;
        isCrewActive = false;
        player.camera.RemoveAllCameraTargets();
        player.camera.AddCameraTarget(player.drone.transform);
        CmdSetOffBoard();
    }
    
    [Command]
    private void CmdSetOffBoard()
    {
        RpcSetOffBoard();
    }

    // Maybe pass it the drone component it'll be using?
    [ClientRpc]
    private void RpcSetOffBoard()
    {
        Debug.Log("Toggle Rpc Received");
        player.drone.gameObject.SetActive(true);
        player.crew.gameObject.SetActive(false);
    }
}
