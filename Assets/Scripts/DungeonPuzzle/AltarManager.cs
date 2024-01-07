using SchoolAdventure.DungeonPuzzle.Puzzle;
using System;
using System.Collections;
using UnityEngine;

namespace SchoolAdventure.DungeonPuzzle
{
    static class RandomExtensions
    {
        public static void Shuffle<T>(this System.Random a, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = a.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
    public class AltarManager : MonoBehaviour
    {
        [SerializeField] GameObject[] _altarPrefab;
        GameObject[] _altars;

        [SerializeField] PuzzleManager _puzzle;
        [SerializeField] Transform _altarParent;
        //Transform[] _altarSpawnPoint;
        public int RemainingAltar;
        [HideInInspector] public bool ready = false;
        int _lastId = -1;
        bool _parfaitAchievment = true;

        // return bool, if not right order return false. if not memry true
        public bool AltarActivated(int altarId)
        {
            if (altarId == _lastId +1)
            {
                RemainingAltar--;
                if (RemainingAltar <= 0)
                {
                    if (_parfaitAchievment)
                    {
                        Success.SuccessHandler.Instance.UnlockAchievment(42);
                    }
                    _puzzle.DoorUnlock();
                }
                _lastId = altarId;
                return true;
            }
            _parfaitAchievment = false;
            return false;
        }


        public void init()
        {
            /*int maxAltar = _altarParent.childCount;
            for (int i = 0; i <= maxAltar; i++)
            {
                _altarSpawnPoint[i] = _altarParent.GetChild(i);
            }*/
            // get Remaining tower and spawnpoints from room
            _altars = new GameObject[RemainingAltar];
            for (int i = 0; i < RemainingAltar; i++)
            {
                        _altars[i] = Instantiate(_altarPrefab[0], new Vector2(_altarParent.GetChild(i).position.x, _altarParent.GetChild(i).position.y - 1.5f), Quaternion.identity, _altarParent);
                /*switch (i)
                {
                    case 0:
                        break;
                    case 1:
                        _altars[i] = Instantiate(_altarPrefab[1], _altarSpawnPoint[i].position, Quaternion.identity, _altarParent);
                        break;
                    default:
                        break;
                }*/
                _altars[i].GetComponent<Altars>().manager = this;
            }
        }

        

        IEnumerator waitSeconds()
        {
            int length = _altars.Length;
            for (int i = 0; i < length; i++)
            {
                _altars[i].GetComponent<Altars>().ShowOrder(i);
                yield return new WaitForSeconds(2);
                _altars[i].GetComponent<Altars>().HideOrder();
            }
            ready = true;
        }

        public void MemoryGame()
        {
            init();
            // need to change the shuffle way
            var rng = new System.Random();
            rng.Shuffle(_altars);
            StartCoroutine(waitSeconds());
        }

        public void StartArea()
        {
            init();
            ready = true;
        }
    }
}
