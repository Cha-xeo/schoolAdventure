
using System;
using SchoolAdventure.DungeonPuzzle.Scriptable.Elements;
using UnityEngine;

namespace SchoolAdventure.DungeonPuzzle.Scriptable.Towers
{
    public enum TowerState
    {
        NonActivated,
        Activated,
        Timed
    }
    [System.Serializable]
    [CreateAssetMenu(fileName = "New dungeon tower", menuName = "Scriptable tower")]
    public class TowerScriptable : ScriptableObject
    {
        public DungeonPuzzle.Towers.TowerID ID;
        public ElementScriptable[] element;
        public TowerState state;
        public Sprite ObjectSprite;
        public GameObject statuePrefab;
        public Sprite[] ElementSprite;
    }
}
