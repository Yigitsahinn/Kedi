using Ink.Parsed;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NailSO", menuName = "Scriptable Objects/NailSO")]
public class NailSO : ScriptableObject
{
    public NailType nailType;
    public List<string> suspects;
}


public enum NailType
{
    None,
    yellow,
    black,
    green
}
