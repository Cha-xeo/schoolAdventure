using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Gameplay.UI
{
    public class UISettingsController : MonoBehaviour
    {
        [SerializeField] GameObject _SettingPanelRoot;
        private static UISettingsController _instance;
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                //DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(this);
            }

        }
        public static UISettingsController GetInstance()
        {
            return _instance;
        }

        public void PauseMenu()
        {
            AplicationController.AplicationController.Instance.gameIsPaused = !AplicationController.AplicationController.Instance.gameIsPaused;
            Time.timeScale = AplicationController.AplicationController.Instance.gameIsPaused ? 0f : 1f;
        }
    }
}