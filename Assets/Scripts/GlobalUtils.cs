using SchoolAdventure.Gameplay.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ap = SchoolAdventure.AplicationController.AplicationController;

namespace SchoolAdventure.Utils
{
    public  class GlobalUtils : MonoBehaviour
    {
        public void LoadMap(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public static class StaticUtils
    {
        /// <summary>
        /// Load scene to transition from scene A to B  in the same game
        /// </summary>
        /// <param name="sceneName"></param>
        public static void LoadMap(string sceneName)
        {
            
            SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// Load scene from a new game
        /// </summary>
        /// <param name="gameSceneName"></param>
        public static void LoadGame(string gameSceneName, int id)
        {
            // start timer
            if ((id == Constants.GAMESELECTION_ID || id == Constants.OPENWORLD_ID) &&
                Ap.Instance.loadedGameID != Constants.GAMESELECTION_ID &&
                Ap.Instance.loadedGameID != Constants.OPENWORLD_ID) 
            {
                Ap.Instance.SaveTime();
            }
            // reset timer
            else
            {
                Ap.Instance.StartRecordTime();
            }
            //AplicationController.AplicationController.Instance.SetTime();
            Ap.Instance.loadedGameID = id;
            SceneManager.LoadScene(gameSceneName);
        }

        /// <summary>
        /// Need to be calleed when exiting a game to reset the help menu
        /// </summary>
        /// <param name="gameName"></param>
        public static void ExitGame(string gameName, int id) // TODO ID
        {
            SchoolAdventure.Audio.SoundManagerV2.Instance.StopAllSounds();
            UISettingsCanvas.GetInstance().ResetHelp();
            LoadGame(gameName, id);
        }
    }
}