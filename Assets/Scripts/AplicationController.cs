using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.AplicationController
{
    public enum QuitMode
    {
        ReturnToMenu,
        ReturnToGameSelection,
        QuitApplication
    }

    public class AplicationController : MonoBehaviour
    {
        public static AplicationController Instance { get; private set; }
        public bool gameIsPaused;
        public bool isQuitLobby;
        [HideInInspector] public List<(string, int)> GameList = new List<(string, int)>();

        [SerializeField] bool _souldloadSelection;

        public int loadedGameID = 0;
        DateTime _timeBuffer;

        void Awake()
        {
            if (Instance)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        public QuitMode m_QuitMode = QuitMode.ReturnToGameSelection;

        // Start is called before the first frame update aled
        void Start()
        {
            Application.wantsToQuit += OnWantToQuit;
            DontDestroyOnLoad(gameObject);
            Application.targetFrameRate = 120;

            if (_souldloadSelection)
            {
                SceneManager.LoadScene("GameSelection");
                //Utils.StaticUtils.LoadGame("GameSelection", 0);
            }
        }


        private bool OnWantToQuit()
        {
            //var canQuit = string.IsNullOrEmpty(m_LocalLobby?.LobbyID);
            bool canQuit = true;
            if (!canQuit)
            {
                StartCoroutine(LeaveBeforeQuit());
            }
            return canQuit;
        }

        /// <summary>
        ///     In builds, if we are in a lobby and try to send a Leave request on application quit, it won't go through if we're quitting on the same frame.
        ///     So, we need to delay just briefly to let the request happen (though we don't need to wait for the result).
        /// </summary>
        private IEnumerator LeaveBeforeQuit()
        {
            yield return null;
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void StartRecordTime()
        {
            _timeBuffer = DateTime.Now;
            Debug.Log("Start recording: "+ _timeBuffer);
        }

        public void SaveTime()
        {
            int interval = (int)(DateTime.Now - _timeBuffer).TotalMinutes;
            Debug.Log("Saving time: " + interval);
            //if (interval > 0) SQLHandler.Instance.SendTime(loadedGameID, interval, playerID);
        }
    }
}
