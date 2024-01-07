using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Dungeon.Generation
{
    public class BulletController : MonoBehaviour
    {
        public float lifeTime;
        public bool isEnemyBullet = false;

        private Vector2 lastPos;
        private Vector2 curPos;
        private Vector2 playerPos;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(DeathDelay());
            if (!isEnemyBullet)
            {
                transform.localScale = new Vector2(GameController.BulletSize, GameController.BulletSize);
            }
        }

        void Update()
        {
            if (isEnemyBullet)
            {
                curPos = transform.position;
                transform.position = Vector2.MoveTowards(transform.position, playerPos, 5f * Time.deltaTime);
                if (curPos == lastPos)
                {
                    //Disable();
                    Destroy(gameObject);
                }
                lastPos = curPos;
            }
        }

        public void GetPlayer(Transform player)
        {
            playerPos = player.position;
        }

        IEnumerator DeathDelay()
        {
            yield return new WaitForSeconds(lifeTime);
            Disable();
            //Destroy(gameObject);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Enemy" && !isEnemyBullet)
            {
                col.gameObject.GetComponent<EnemyController>().Death();
                Disable();
                //Destroy(gameObject);
            }

            if (col.tag == "Player" && isEnemyBullet)
            {
                GameController.DamagePlayer(1);
                //Disable();
                Destroy(gameObject);
            }
        }

        private void Disable()
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }
}
