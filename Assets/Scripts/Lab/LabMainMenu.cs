using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SchoolAdventure.Games.Lab.Manager;
using SchoolAdventure.Audio;

namespace SchoolAdventure.Games.Lab
{
    public class LabMainMenu : MonoBehaviour
    {
        //[SerializeField] private Canvas _mainMenuCanvas;
        [SerializeField] private LabMusic _musicHandler;
        [SerializeField] private LabGameManager _gameManager;
        public AudioClip soundEffect;
        [SerializeField] private LabLevelLoader _levelLoader;
        [SerializeField] private Button _playBtn;
        public void PlayGame()
        {
            _playBtn.interactable = false;
            SoundManagerV2.Instance.PlaySound(soundEffect);
            //_mainMenuCanvas.gameObject.SetActive(false);
            _gameManager.StartGame();
            _levelLoader.StartTransition();
            //_gameManager.SceneAdvance();
        }

        public void QuitGame(string name)
        {
            SoundManagerV2.Instance.PlaySound(soundEffect);
            SceneManager.LoadScene(name);
            //Debug.LogWarning("Implement return to lobby function");
        }

    }
}