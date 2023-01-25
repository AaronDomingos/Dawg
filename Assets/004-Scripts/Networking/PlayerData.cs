using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This type provides a convenient storage medium for data encompassed by an individual player. */
[Serializable]
public struct PlayerData : IEquatable<PlayerData>
{
    // Fields
    [SerializeField] private string playerName;
    [SerializeField] private bool isReady;

    // Constructor
    public PlayerData(string name, bool isReady)
    {
        this.playerName = name;
        this.isReady = isReady;
    }

    // Getters and setters
    public string Name { get => playerName; set => playerName = value; }
    public bool IsReady { get => isReady; set => isReady = value; }

    // Define equivalency between instances of this type
    public bool Equals(PlayerData other)
    {
        if(playerName == other.playerName && isReady == other.isReady)
        {
            return true;
        }

        return false;
    }

    public string SaveToJsonString()
    {
        return JsonUtility.ToJson(this);
    }

    public void ParseFromJsonString(string json)
    {
        JsonUtility.FromJson<PlayerData>(json);
    }
}
