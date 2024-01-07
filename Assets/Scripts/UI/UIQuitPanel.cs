using SchoolAdventure.AplicationController;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.UI
{
    public class UIQuitPanel : MonoBehaviour
    {
        [SerializeField] GameObject _quitButton;
        void Start()
        {
#if PLATFORM_WEBGL
            _quitButton.SetActive(false);
#endif
        }

        public void Quit()
        {
            switch (AplicationController.AplicationController.Instance.m_QuitMode)
            {
                case QuitMode.ReturnToMenu:
                    SceneManager.LoadScene("MainMenuDonjonPuzzle");
                    break;
                case QuitMode.ReturnToGameSelection:
                    Audio.SoundManagerV2.Instance.StopAllSounds();
                    SceneManager.LoadScene("GameSelection");

                    break;
                case QuitMode.QuitApplication:
#if !UNITY_EDITOR
			        Application.Quit();
#endif

#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#endif
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            gameObject.SetActive(false);
        }
        public void QuitGame()
        {
            // TODO Pop-up to ask if you really want to quit
        #if !UNITY_EDITOR
			Application.Quit();
        #endif

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        }

        public void ReturnToLobby()
        {
            Utils.StaticUtils.ExitGame(Constants.SCENE_LOBBY, Constants.OPENWORLD_ID);
        }

        public void ReturnTSelection()
        {
            Utils.StaticUtils.ExitGame(Constants.SCENE_SELECTION, Constants.GAMESELECTION_ID);
        }
    }

}
