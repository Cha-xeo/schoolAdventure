using System;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Dungeon.Player.UI
{
    public class PlayerUI : MonoBehaviour
    {
        public Text collectedText;

        private void Start()
        {
            DungeonPuzzle.Player.PlayerManager.Instance.onItemPickedUp += PlayerManager_onItemPickedUp;
        }
        public void OnCollected()
        {
            collectedText.text = "Items Collected: " + DungeonPuzzle.Player.PlayerManager.Instance.collectedAmount;
        }


        void PlayerManager_onItemPickedUp(object sender, System.EventArgs e)
        {
            OnCollected();
        }

        private void OnDestroy()
        {
            DungeonPuzzle.Player.PlayerManager.Instance.onItemPickedUp -= PlayerManager_onItemPickedUp;

        }
    }
}
