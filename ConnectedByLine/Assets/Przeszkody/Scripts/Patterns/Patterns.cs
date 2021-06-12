using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pattern", menuName = "ScriptableObjects/Pattern")]
public class Patterns : ScriptableObject
{
    public List<PatternColumns> col;
}
