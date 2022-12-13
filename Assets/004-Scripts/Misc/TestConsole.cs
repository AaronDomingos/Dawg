using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TestConsole : NetworkBehaviour
{
    public SpriteRenderer sprite;
    private Vector3 testMovement = new Vector3(.001f, 0f, 0f);

    [ClientRpc]
    public void InteractClientRpc()
    {
        sprite.color = Color.green;
    }

    public void Failed()
    {
        sprite.color = Color.red;
    }
}
