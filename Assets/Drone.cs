using System;
using System.Collections;
using System.Collections.Generic;
using Suriyun.MCS;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public Movement movement;

    public void HandleThrust(Vector3 direction)
    {
        movement.SetDirection(direction);
    }
}
