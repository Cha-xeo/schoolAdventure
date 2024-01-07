using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SchoolAdventure.Games.Lab
{
    public class LabEnnemyChaser : MonoBehaviour
    {
        public float speed = 3f;
        public int value = 1;
        private Transform target;

        void Update()
        {
            if (target)
            {
                Vector3 aled = new Vector3(target.position.x, target.position.y - 0.7f, target.position.z);
                transform.position = Vector2.MoveTowards(transform.position, aled, speed * Time.deltaTime);
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Debug.Log(other.tag);
            if (other.gameObject.CompareTag(Constants.TAG_PLAYER))
            {
                target = other.transform;
                // Debug.Log(target);
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Constants.TAG_PLAYER))
            {
                target = null;
                // Debug.Log(target);
            }
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            // Debug.Log(gameObject.tag);
            if (other.gameObject.CompareTag(Constants.TAG_PLAYER))
            {
                switch (gameObject.tag)
                {
                    case "Coin":
                        other.gameObject.SendMessage("AddCoins", value);
                        break;
                    case "Key":
                        other.gameObject.SendMessage("AddKeys", value);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}