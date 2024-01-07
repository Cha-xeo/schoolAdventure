using SchoolAdventure.DungeonPuzzle.Puzzle;
using System;
using UnityEngine;

namespace SchoolAdventure.DungeonPuzzle.Towers
{
    public class TowerManager : MonoBehaviour
    {
        [SerializeField] GameObject[] _towersPrefab;
        GameObject[] _towers;

        [SerializeField] PuzzleManager _puzzle;
        [SerializeField] Transform _towerParent;
        //Transform[] _towerSpawnPoint;
        public int RemainingTower;
        [HideInInspector] public bool ready = false;

        public void TowerActivated()
        {
            RemainingTower--;
            if (RemainingTower <= 0)
            {
                _puzzle.DoorUnlock();
            }
        }

        public void init()
        {
            /*int maxTower = _towerParent.childCount;
            for (int i = 0; i <= maxTower; i++)
            {
                _towerSpawnPoint[i] = _towerParent.GetChild(i);
            }*/

            // get Remaining tower and spawnpoints from room
            _towers = new GameObject[RemainingTower];
            for (int i = 0; i < RemainingTower; i++)
            {
                        _towers[i] = Instantiate(_towersPrefab[UnityEngine.Random.Range(0, _towersPrefab.Length)], _towerParent.GetChild(i).position, Quaternion.identity, _towerParent);
                /*switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        _towers[i] = Instantiate(_towersPrefab[1], _towerSpawnPoint[i].position, Quaternion.identity, _towerParent);
                        break;
                    default:
                        break;
                }*/
                _towers[i].GetComponent<Tower>().manager = this;
            }
        }

        public void StartArea()
        {
            init();
            ready = true;
        }

        public void TowerMatch()
        {
            init();
            ready = true;
        }
    }
}
