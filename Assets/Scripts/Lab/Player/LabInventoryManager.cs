using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Lab.Player
{
    public class LabInventoryManager : MonoBehaviour
    {
        private int _keys = 0;
        public int Keys
        {
            get
            {
                return _keys;
            }
            set
            {
                if (value == 1)
                {
                    Success.SuccessHandler.Instance.UnlockAchievment(34);
                }
                _keys = value;
                Debug.Log(_keys);
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Constants.TAG_PLAYER))
            {
                PickUpItem(other.gameObject);
            }
        }

        public bool PickUpItem(GameObject obj)
        {
            switch (obj.tag)
            {
                case Constants.TAG_KEY:
                    Keys++;
                    return true;
                default:
                    Debug.LogWarning($"Warning no handler for this tag {obj.tag} in pickup");
                    return false;
            }
        }
    }
}