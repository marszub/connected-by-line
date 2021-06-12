using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllPattern", menuName = "ScriptableObjects/AllPattern")]
public class AllPatterns : ScriptableObject
{
    public List<Patterns> pate;

    public List<PatternColumns> GiveRand()
    {
        int numb = pate.Count;
        int randInd = Random.Range(0, numb);
        return pate[randInd].col;
    }
        
}


