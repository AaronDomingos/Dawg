using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TestConsole : NetworkBehaviour
{
    public SpriteRenderer sprite;

    [ClientRpc]
    public void InteractClientRPC()
    {
        sprite.color = Color.green;
    }

    public void Failed()
    {
        sprite.color = Color.red;
    }
}
