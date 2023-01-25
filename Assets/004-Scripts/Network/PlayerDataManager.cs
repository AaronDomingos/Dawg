using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

/* This class contains methods for handling player data and tracks all existing player data in a synced dictionary */
public class PlayerDataManager : NetworkBehaviour
{
    public static PlayerDataManager singleton { get; private set; }

    // Dictionary containing json data corresponding to each player's client ID
    private readonly SyncDictionary<uint, string> playerDataDictionary = new SyncDictionary<uint, string>();

    [Command(requiresAuthority = false)]
    public void DeletePlayerData(uint netId)
    {
        playerDataDictionary.Remove(netId);
    }

    [Command(requiresAuthority = false)]
    public void CmdUpdatePlayerData(uint netId, PlayerData playerData)
    {
        if (playerDataDictionary.ContainsKey(netId))
        {
            playerDataDictionary.Remove(netId);
        }

        playerDataDictionary.Add(netId, playerData.SaveToJsonString());
        Debug.Log("Updated player data for connId " + netId + playerDataDictionary[netId]);
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

        DontDestroyOnLoad(this);
    }
}
