using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PatternColumn", menuName = "ScriptableObjects/PatternColumn")]
public class PatternColumns : ScriptableObject
{
    public float width;

    public List<string> pat_type;

    public List<Vector2> pat_vec;
}


