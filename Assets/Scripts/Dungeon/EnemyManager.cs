using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SchoolAdventure.Dungeon.Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager Instance { get; private set; }
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

        [SerializeField] Transform[] _enemySpawn;
        [SerializeField] GameObject _enemyPrefab;
        GameObject[] _enemyInstanceArray = new GameObject[2];

        private void Start()
        {
            _enemyInstanceArray[0] = Instantiate(_enemyPrefab, _enemySpawn[0].position, Quaternion.identity, _enemySpawn[0]);
        }

        private void OnDisable()
        {
            // reset enemy
        }
    }
}