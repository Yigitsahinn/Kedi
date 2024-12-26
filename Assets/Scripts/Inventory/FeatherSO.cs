using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FeatherSO", menuName = "Scriptable Objects/FeatherSO")]
public class FeatherSO : ScriptableObject
{
    public FeatherType featherType;
    public List<string> suspects;
}

public enum FeatherType
{
    None,
    green,
    yellow,
    black
}
