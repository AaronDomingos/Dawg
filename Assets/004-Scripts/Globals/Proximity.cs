using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Proximity
{
    public static Vector3 DirectionToObject(GameObject a, GameObject b)
    {
        return (b.transform.position - a.transform.position).normalized;
    }
    
    public static float BetweenGameObjects(GameObject a, GameObject b)
    {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }

    public static float ToNearestGameObject(GameObject origin, List<GameObject> objects)
    {
        return BetweenGameObjects(origin, NearestGameObject(origin, objects));
    }

    public static float ToFurthestGameObject(GameObject origin, List<GameObject> objects)
    {
        return BetweenGameObjects(origin, FurthestGameObject(origin, objects));
    }

    public static GameObject NearestGameObject(GameObject origin, List<GameObject> objects)
    {
        return OrderGameObjectsByProximity(origin, objects).First();
    }

    public static GameObject FurthestGameObject(GameObject origin, List<GameObject> objects)
    {
        return OrderGameObjectsByProximity(origin, objects).Last();
    }

    public static List<GameObject> OrderGameObjectsByProximity(GameObject origin, List<GameObject> objects)
    {
        return objects.OrderBy(x => BetweenGameObjects(origin, x)).ToList<GameObject>();
    }
}
