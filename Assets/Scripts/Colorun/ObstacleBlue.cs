using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Mathematique.Colorun
{
    public class ObstacleBlue : MonoBehaviour
    {
        private GameObject player;
        public int getColor;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        void Update()
        {
            getColor = ColorunPlayer.targetColor;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Border")
            {
                Destroy(this.gameObject);
            }
            else if (collision.tag == "Player")
            {
                Destroy(this.gameObject);
            }
        }
    }
}