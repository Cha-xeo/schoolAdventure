using SchoolAdventure.DungeonPuzzle.Player.Elements;
using System;
using UnityEngine;

namespace SchoolAdventure.DungeonPuzzle.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance { get; private set; }
        void Awake()
        {
            if (Instance)
            {
                Destroy(Instance);
            }
            else
            {
                Instance = this;
            }
        }
        public ElementsScript Element { get; private set; }
        public event EventHandler onElementChanged;
        public event EventHandler onItemPickedUp;

        public int collectedAmount = 0;

        private void Start()
        {
            Element = GetComponent<ElementsScript>();
        }

        public void ItemPickedUp()
        {
            onItemPickedUp?.Invoke(this, EventArgs.Empty);
        }
        public void ElementChanged()
        {
            onElementChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
