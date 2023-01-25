using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

/* This class contains methods for handling player data and tracks all existing player data in a synced dictionary */
public class PlayerDataManager : NetworkBehaviour
{
    public static PlayerDataManager singleton { get; private set; }

    // Dictionary containing json data corresponding to each player's client ID
    private readonly SyncDictionary<int, string> playerDataDictionary = new SyncDictionary<int, string>();

    [Command(requiresAuthority = false)]
    public void DeletePlayerData(int connId)
    {
        playerDataDictionary.Remove(connId);
    }

    [Command(requiresAuthority = false)]
    public void CmdUpdatePlayerData(int connId, string playerDataJson)
    {
        if (playerDataDictionary.ContainsKey(connId))
        {
            playerDataDictionary.Remove(connId);
        }

        playerDataDictionary.Add(connId, playerDataJson);
        Debug.Log("Updated player data for connId " + connId + playerDataDictionary[connId]);
    }

    private void Awake()
    {
        // If there's another instance that's not this object, destroy this object
        if(singleton != null && singleton != this)
        {
            Destroy(this);
        } else
        {
            singleton = this;
        }
    }
}
