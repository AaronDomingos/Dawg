using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

/* This type provides a convenient storage medium for data encompassed by an individual player. */
[Serializable]
public struct PlayerData : IEquatable<PlayerData>
{
    // Fields
    [SerializeField] private uint netId;
    [SerializeField] private string playerName;
    [SerializeField] private bool isReady;

    // Constructor
    public PlayerData(uint netId, string name, bool isReady)
    {
        this.netId = netId;
        this.playerName = name;
        this.isReady = isReady;
    }

    // Getters and setters
    public uint NetId { get => netId; set => netId = value; }
    public string PlayerName { get => playerName; set => playerName = value; }
    public bool IsReady { get => isReady; set => isReady = value; }

    // Define equivalency between instances of this type
    public bool Equals(PlayerData other)
    {
        if (netId == other.netId && playerName == other.playerName && isReady == other.isReady)
        {
            return true;
        }

        return false;
    }

    public string SaveToJsonString()
    {
        return JsonUtility.ToJson(this);
    }

    public static PlayerData ParseFromJsonString(string json)
    {
        return JsonUtility.FromJson<PlayerData>(json);
    }
}

/* Custom reader and writer for serialization */
public static class CustomReadWriteFunctions
{
    public static void WritePlayerData(this NetworkWriter writer, PlayerData value)
    {
        writer.WriteUInt(value.NetId);
        writer.WriteString(value.PlayerName);
        writer.WriteBool(value.IsReady);
    }

    public static PlayerData ReadPlayerData(this NetworkReader reader)
    {
        return new PlayerData(reader.ReadUInt(), reader.ReadString(), reader.ReadBool());
    }
}
