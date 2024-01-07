using SchoolAdventure.Audio;
using SchoolAdventure.Games.Lab.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Lab
{
    public class LabStartGameDoor : MonoBehaviour
    {
        [SerializeField] LabGameManager _gameManager;
        private float _musicVolume;
        [SerializeField] private LabLevelLoader _levelLoader;

        public void StartGame()
        {
            _gameManager._playerPrefab.gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(true);
        }

        public void Win()
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.gameObject.SetActive(false);
            //_gameManager.SceneAdvance();
            _levelLoader.StartTransition();
            _gameManager._playerPrefab.gameObject.SetActive(true);
        }

        public void CloseGame()
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.gameObject.SetActive(false);
            _gameManager._playerPrefab.gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            StartGame();
            _musicVolume = SoundManagerV2.Instance.GetMusicVolume();
            SoundManagerV2.Instance.ChangeMusicVolume(0.005f);
        }

        private void OnDisable()
        {
            SoundManagerV2.Instance.ChangeMusicVolume(_musicVolume);
        }
    }
}
