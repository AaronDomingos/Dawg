using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Orientation
{
    public static Quaternion Default = new Quaternion(0,0,0,0);

    public static Vector3 RandomDirection()
    {
        return Random.insideUnitCircle.normalized;
    }

    public static Vector3 DirectionToObject(GameObject a, GameObject b)
    {
        return (b.transform.position - a.transform.position).normalized;
    }

    public static Vector3 DirectionToVector(Vector3 a, Vector3 b)
    {
        return (b - a).normalized;
    }

    public static Quaternion DirectionToQuarternion(Vector3 direction)
    {
        return Quaternion.Euler(direction.x, direction.y, direction.z);
    }

    public static Quaternion QuarternionFromAToB(Transform a, Vector3 b, float speed)
    {
        Vector3 directionTo = DirectionToVector(a.position, b);
        Quaternion rotationTo = Quaternion.LookRotation(Vector3.forward, directionTo);
        return Quaternion.Lerp(a.rotation, rotationTo, (speed * Time.deltaTime));
    }
}
