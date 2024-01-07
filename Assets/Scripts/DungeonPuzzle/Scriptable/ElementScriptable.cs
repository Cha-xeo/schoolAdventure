
using UnityEngine;

namespace SchoolAdventure.DungeonPuzzle.Scriptable.Elements
{
    public enum Elements
    {
        Fire,
        Ice,
        lightning,
        None
    }
    [System.Serializable]
    [CreateAssetMenu(fileName = "New element", menuName = "Scriptable element")]
    public class ElementScriptable : ScriptableObject
    {
        public DungeonPuzzle.Elements.ElementID ID;
        public string Name;
        public Elements Elements;
        public Color color;
    }
}
