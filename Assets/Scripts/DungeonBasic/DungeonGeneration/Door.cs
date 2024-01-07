using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Dungeon.Generation
{
    public class Door : MonoBehaviour
    {
        public enum DoorType
        {
            left, right, top, bottom
        }

        public DoorType doorType;

        //public GameObject doorCollider;
        public BoxCollider2D doorCollider;

        private GameObject player;
        private float widthOffset = 4f;
        bool _activated = false;

        private void Start()
        {
            doorCollider = GetComponent<BoxCollider2D>();
            player = GameController.Instance.GetPlayer();
            //player = GameObject.FindGameObjectWithTag("Player");
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (!_activated) return;
            if (other.CompareTag(Constants.TAG_PLAYER))
            {
                switch (doorType)
                {
                    case DoorType.bottom:
                        player.transform.position = new Vector2(transform.position.x, transform.position.y - widthOffset);
                        break;
                    case DoorType.left:
                        player.transform.position = new Vector2(transform.position.x - widthOffset, transform.position.y);
                        break;
                    case DoorType.right:
                        player.transform.position = new Vector2(transform.position.x + widthOffset, transform.position.y);
                        break;
                    case DoorType.top:
                        player.transform.position = new Vector2(transform.position.x, transform.position.y + widthOffset);
                        break;
                }
            }
        }

        public void UnlockDoor()
        {
            _activated = true;
        }
    }
}