using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Mathematique.Pyrun
{
    public class Spawner : MonoBehaviour
    {
        // Start is called before the first frame update

        private float timeBtwSpawns;
        public float startTimeBtwSpawns;
        public float timeDecrease;
        public float minTime;

        public GameObject[] myTemplate;
        [SerializeField] Transform _chestparent;
        public Player _player;

        private void Start()
        {
            timeBtwSpawns = startTimeBtwSpawns;
        }

        private void Update()
        {
            if (_player.tutoEnd == true) {
                if (timeBtwSpawns <= 0)
                {
                    int rand = Random.Range(0, myTemplate.Length);
                    Instantiate(myTemplate[rand], transform.position, Quaternion.identity, _chestparent);
                    timeBtwSpawns = startTimeBtwSpawns;
                    if (startTimeBtwSpawns > minTime)
                    {
                        // TODO Spawner il est casser
                        //startTimeBtwSpawns -= (float)0.2;
                    }
                }
                else
                {
                    timeBtwSpawns -= Time.deltaTime;
                }
            }
        }
    }
}