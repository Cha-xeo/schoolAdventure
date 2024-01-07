using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace SchoolAdventure.Games.Geometrie
{
    public class ScoreManagerGeometry : MonoBehaviour
    {
        public static ScoreManagerGeometry instance;
        public TMP_Text scoreText;
        public static int score = 0;

        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            scoreText.text = score.ToString() + " Points";
        }

        public void addPoint()
        {
            score++;
            if (score == 15) {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(20);
            } else if (score == 100 && SceneManager.GetActiveScene().name == "LevelOneScene") {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(21);
            } else if (score == 100 && SceneManager.GetActiveScene().name == "LevelTwoScene") {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(22);
            } else if (score == 100 && SceneManager.GetActiveScene().name == "LevelThreeScene") {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(23);
            }
            scoreText.text = score.ToString() + " Points";
        }

        public void removePoint()
        {
            if (score > 0)
                score--;
            scoreText.text = score.ToString() + " Points";
        }
    }
}
