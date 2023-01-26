using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Identity : MonoBehaviour
{
    public List<Identification.Tags> TagsKnownAs = new List<Identification.Tags>();

    public void Add(Identification.Tags tag)
    {
        if (!TagsKnownAs.Contains(tag)) 
        { TagsKnownAs.Add(tag); }
    }

    public void Remove(Identification.Tags tag)
    {
        if (TagsKnownAs.Contains(tag)) 
        { TagsKnownAs.Remove(tag); }
    }

    public bool IsBothAAndB(Identification.Tags a, Identification.Tags b)
    {
        if(TagsKnownAs.Contains(a) && TagsKnownAs.Contains(b)) 
        { return true; }
        { return false; }
    }

    public bool IsAButNotB(Identification.Tags a, Identification.Tags b)
    {
        if (TagsKnownAs.Contains(a) && !TagsKnownAs.Contains(b))
        { return true; }
        { return false; }
    }
}
