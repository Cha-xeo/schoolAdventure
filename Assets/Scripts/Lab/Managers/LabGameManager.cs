using Cinemachine;
using SchoolAdventure.Games.Lab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Lab.Manager
{
    public class LabGameManager : MonoBehaviour
    {
        public int currentScene = 0;
        [SerializeField] GameObject _player;
        public GameObject _playerPrefab;
        Transform _playerPrefabTransform;
        [SerializeField] Transform _spawnPoints;
        [SerializeField] Transform _worldsBoundary;
        [SerializeField] CinemachineConfiner _CamConfiner;
        [SerializeField] CinemachineVirtualCamera _virtualCam;
        [SerializeField] Canvas _mainMenuCanvas;
        [SerializeField] LabMusic _musicHandler;
        [SerializeField] Button _playBtn;

        private void FixedUpdate()
        {
            if (InputManager.GetInstance().GetEscapePressed())
            {
                _playerPrefabTransform = null;
                _virtualCam.Follow = null;
                _CamConfiner.m_BoundingShape2D = null;
                _musicHandler.OnGameScene(0);
                currentScene = 0;
                _mainMenuCanvas.gameObject.SetActive(true);
                _playBtn.interactable = true;
                Destroy(_playerPrefab);
            }
        }

        public void StartGame()
        {
            _playerPrefab = Instantiate(_player, _spawnPoints.GetChild(currentScene).position, Quaternion.identity);
            _playerPrefabTransform = _playerPrefab.transform;
            _virtualCam.Follow = _playerPrefabTransform;
        }
        public void SceneAdvance()
        {
            _playerPrefabTransform.position = _spawnPoints.GetChild(currentScene).position;
            _CamConfiner.m_BoundingShape2D = _worldsBoundary.GetChild(currentScene).GetComponent<PolygonCollider2D>();
            _musicHandler.OnGameScene(++currentScene);
        }
    }
}