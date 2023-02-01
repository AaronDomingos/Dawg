using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class IdDetector : MonoBehaviour
{
    public float Range = 1;
    public List<Identification.Tags> TagsToDetect = new List<Identification.Tags>();
    public List<GameObject> DetectedObjects = new List<GameObject>();

    public List<TagPairing> BothAAndB = new List<TagPairing>();
    public List<TagPairing> NotAAndB = new List<TagPairing>();

    [System.Serializable]
    public struct TagPairing
    {
        public Identification.Tags A;
        public Identification.Tags B;

        public TagPairing(Identification.Tags a, Identification.Tags b)
        {
            A = a;
            B = b;
        }
    }
    
    void Start()
    {
        //transform.localScale = new Vector3(Range, Range);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;
        if(obj.TryGetComponent(out Identity id) &&
            id.TagsKnownAs.Intersect(TagsToDetect).Any())
        {
            // Object is both A and B for all Good Pairings
            bool hasAGoodPairing = false;
            if (BothAAndB.Count == 0)
            {
                hasAGoodPairing = true;
            }
            foreach (TagPairing pair in BothAAndB)
            {
                if (id.TagsKnownAs.Contains(pair.A) &&
                    id.TagsKnownAs.Contains(pair.B))
                {
                    hasAGoodPairing = true;
                    break;
                }
            }
            // Object is not A and B for any Bad Pairings
            bool isNoBadPairings = true;
            foreach (TagPairing pair in NotAAndB)
            {
                if (id.TagsKnownAs.Contains(pair.A) &&
                    id.TagsKnownAs.Contains(pair.B))
                {
                    isNoBadPairings = false;
                    break;
                }
            }
            // All criteria is met
            if (hasAGoodPairing && isNoBadPairings)
            {
                DetectedObjects.Add(col.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (DetectedObjects.Contains(col.gameObject))
        {
            DetectedObjects.Remove(col.gameObject);
        }
    }

    private bool IsSearchingFor(GameObject obj)
    {
        return obj.GetComponent<Identity>().TagsKnownAs.Intersect(TagsToDetect).Any();
    }
}
