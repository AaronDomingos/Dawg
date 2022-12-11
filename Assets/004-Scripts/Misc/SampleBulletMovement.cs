using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class SampleBulletMovement : NetworkBehaviour
{
    private void Update()
    {
        transform.position += new Vector3(1, 1, 0) * .005f;
    }
}
