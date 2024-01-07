using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New game", menuName = "Scriptable games")]
public class ScriptableGames : ScriptableObject
{
    public int ID;
    public string _name;
    public string _description;
    public string _sceneName;
    public string _matiere;
    public Sprite _icon;
    public bool includeInBuild = false;
    public GameObject helpPrefab;
}
