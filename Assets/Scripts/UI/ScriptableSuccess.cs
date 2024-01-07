using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Success", menuName = "Scriptable Success")]
public class ScriptableSuccess : ScriptableObject
{
    public int _id;
    public string _name;
    public string _description;
    public string _gameName;
    //public Sprite _icon;
    public bool _unlocked = false;
}
