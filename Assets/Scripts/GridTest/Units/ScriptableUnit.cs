using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New unit", menuName ="Scriptable unit")]
public class ScriptableUnit : ScriptableObject
{
    public Faction Faction;
    public BaseUnit unitPrefab;
}

public enum Faction
{
    Player,
    Enemy,
}
