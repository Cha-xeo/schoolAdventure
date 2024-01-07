using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Mathematique.Colorun
{
    public class SpawnObstacles : MonoBehaviour
    {
        public GameObject obstacle;
        public GameObject yellow;
        public GameObject red;
        public GameObject blue;
        public GameObject green;
        public GameObject pink;
        public GameObject purple;
        public GameObject black;
        public GameObject white;
        public GameObject beige;
        public GameObject brown;
        public GameObject olive;
        public GameObject orange;
        public GameObject salmon;
        public GameObject turquoise;
        public GameObject gray;
        public GameObject sky;
        public float minX;
        public float timeBetweenSpawn;
        private float spawnTime;
        public int color;
        public int r;
        public int[] rList = new int[4];
        public string[] colors = ColorunPlayer.colors;
        public int stageLevel = 5;

        void Update()
        {
            stageLevel = MainMenu.level;
            if (Time.time > spawnTime && GameObject.FindGameObjectWithTag("Player") != null)
            {
                color = ColorunPlayer.targetColor;
                Spawn();
                rList = new int[4];
                spawnTime = Time.time + timeBetweenSpawn;
            }
        }

        int RandomExcept(int min, int max, int exc)
        {
            int res = Random.Range(min, max);

            while (res == exc) {
                res = Random.Range(min, max);
            }

            return res;
        }

        GameObject getObstacle(int c)
        {
            if (c == 1)
            {
                return yellow;
            }
            else if (c == 2)
            {
                return red;
            }
            else if (c == 3)
            {
                return blue;
            }
            else if (c == 4)
            {
                return green;
            }
            else if (c == 5)
            {
                return pink;
            }
            else if (c == 6)
            {
                return purple;
            }
            else if (c == 7)
            {
                return black;
            }
            else if (c == 8)
            {
                return white;
            }
            else if (c == 9)
            {
                return beige;
            }
            else if (c == 10)
            {
                return brown;
            }
            else if (c == 11)
            {
                return olive;
            }
            else if (c == 12)
            {
                return orange;
            }
            else if (c == 13)
            {
                return salmon;
            }
            else if (c == 14)
            {
                return turquoise;
            }
            else if (c == 15)
            {
                return gray;
            }
            else
            {
                return sky;
            }
        }

        int contains(int[] list, int check)
        {
            foreach (int x in list)
            {
                if (x == check)
                    return 0;
            }
            return 1;
        }

        void Spawn()
        {
            int target = Random.Range(0, 4);
            if (target == 0) {
                r = color;
            } else {
                r = RandomExcept(1, stageLevel, color);
            }
            rList[0] = r;
            obstacle = getObstacle(r);
            Instantiate(obstacle, transform.position + new Vector3(minX, -3.54f, 0), transform.rotation);
            if (target == 1) {
                r = color;
            } else {
                r = RandomExcept(1, stageLevel, color);
                while (contains(rList, r) == 0) {
                    r = RandomExcept(1, stageLevel, color);
                }
            }
            rList[1] = r;
            obstacle = getObstacle(r);
            Instantiate(obstacle, transform.position + new Vector3(minX, -1.44f, 0), transform.rotation);
            if (target == 2) {
                r = color;
            } else {
                r = RandomExcept(1, stageLevel, color);
                while (contains(rList, r) == 0) {
                    r = RandomExcept(1, stageLevel, color);
                }
            }
            rList[2] = r;
            obstacle = getObstacle(r);
            Instantiate(obstacle, transform.position + new Vector3(minX, 0.7f, 0), transform.rotation);
            if (target == 3) {
                r = color;
            } else {
                r = RandomExcept(1, stageLevel, color);
                while (contains(rList, r) == 0) {
                    r = RandomExcept(1, stageLevel, color);
                }
            }
            rList[3] = r;
            obstacle = getObstacle(r);
            Instantiate(obstacle, transform.position + new Vector3(minX, 2.85f, 0), transform.rotation);
        }
    }
}