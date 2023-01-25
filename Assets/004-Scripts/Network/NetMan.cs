using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetMan : NetworkManager
{
    [SerializeField] int maxPlayers = 4;

    public override void OnStartServer()
    {
        maxConnections = maxPlayers;
        Debug.Log(maxConnections);
    }
}
