using SchoolAdventure.Dungeon.Generation;
using SchoolAdventure.DungeonPuzzle.Towers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.DungeonPuzzle
{
    public enum GameState
    {
        MainMenu,
        PLaying,
        GameOver
    }

    public enum PuzzleType
    {
        None,
        Start,
        AltarMemory,
        AltarPickUp,
        TowerMatch,
    }
}

namespace SchoolAdventure.DungeonPuzzle.Puzzle
{
    public enum PuzzleState
    {
        Waiting,
        Generating,
        Playing,
        Completed,
        Done
    }

    public class PuzzleManager : MonoBehaviour
    {
        private PuzzleState _currentState;
        //[SerializeField] GameObject _playerPrefab;
        //[SerializeField] GameObject _ennemyGO;
        GameObject _playerInstance;
        //public GameObject _Door;
        [SerializeField] TowerManager _towerManager;
        [SerializeField] AltarManager _altarManager;
        [SerializeField] AudioClip _completeClip;
        public int RoomPuzzles;
        public PuzzleType PType;
        //[SerializeField] bool _shouldSpawn = true;
        void Awake()
        {
            _currentState = PuzzleState.Waiting;
        }

        public void ActivatePuzzle()
        {
            _currentState = PuzzleState.Generating;
        }
        private void Update()
        {
            switch (_currentState)
            {
                case PuzzleState.Waiting:
                    break;
                case PuzzleState.Generating:
                    // send contruction order to managers
                    switch (PType)
                    {
                        case PuzzleType.None:
                            break;
                        case PuzzleType.Start:
                            _towerManager.StartArea();
                            _altarManager.StartArea();
                            break;
                        case PuzzleType.AltarMemory:
                            _altarManager.MemoryGame();
                            break;
                        case PuzzleType.AltarPickUp:
                            break;
                        case PuzzleType.TowerMatch:
                            _towerManager.TowerMatch();
                            break;
                    }
                    _currentState = PuzzleState.Playing;
                    break;
                case PuzzleState.Playing:
                    break;
                case PuzzleState.Completed:
                    // TODO Find current room and unlock doors
                    Audio.SoundManagerV2.Instance.PlaySound(_completeClip);
                    RoomController.Instance.UnlockRoomDoors();
                    _currentState = PuzzleState.Done;
                    break;
                case PuzzleState.Done:
                    // TODO Fade animation
                    gameObject.SetActive(false);
                    break;
            }
        }
        public GameObject GetPlayer()
        {
            return _playerInstance;
        }
        public void DoorUnlock()
        {
            RoomPuzzles--;
            if (RoomPuzzles <= 0)
            {
               _currentState = PuzzleState.Completed;
            }
            /// else
            /// fire almost complet effect

        }
    }
}
