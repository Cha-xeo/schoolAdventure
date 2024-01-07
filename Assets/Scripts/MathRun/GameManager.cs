using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace SchoolAdventure.Games.MathRun
{
    public class GameManager : MonoBehaviour
    {

        public GameObject endPanel;
        public GameObject pausePanel;
        public GameObject mainMenu;
        public bool gamePaused = false;
        public bool mainMenuActive = true;
        [SerializeField] private TextMeshProUGUI scoreTxt2;


        void Update()
        {
            // if (Input.GetKeyDown(KeyCode.Escape) && !mainMenuActive)

            /*if (InputManager.GetInstance().GetEscapePressed())
            {
                menuPause();
            }
            */

            //Perso.instance.CurrentScore
            //Debug.Log("le score :" + Perso.instance.CurrentScore);
            //scoreTxt2 = Perso.instance.CurrentScore;
            scoreTxt2.text = Perso.instance.CurrentScore.ToString();

        }


        public void menuPause()
        {
            if (!gamePaused)
            {
                gamePaused = true;
                Time.timeScale = 0;
                pausePanel.SetActive(true);

            }
            else
            {
                continueGame();
            }
        }

        public void continueGame()
        {
            gamePaused = false;
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }

        public void replay()
        {
            SceneManager.LoadScene("MathRunLevel1");
            gamePaused = false;

        }

        public void goMainMenu()
        {
            SceneManager.LoadScene("MathRunMenuScene");
        }
        /*public void LeaveGame()
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }*/
    }
}