using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SchoolAdventure.Games.Geographie.GeoPays
{
    public class Score : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;
        private int score = 0;

        void Start()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        public void ScoreUP()
        {
            score++;

            if (scoreText != null)
            {
                scoreText.text = score.ToString();
            }
        }

        public void checkAchievements()
        {
            if (score > 20){
                Success.SuccessHandler.Instance.UnlockAchievment(78);
            }
            if (score > 50){
                Success.SuccessHandler.Instance.UnlockAchievment(79);
            }
            if (score > 100){
                Success.SuccessHandler.Instance.UnlockAchievment(80);
            }
        }

        public void resetScore()
        {
            score = 0;
            scoreText.text = score.ToString();
        }

        public int getScore()
        {
            return score;
        }

        public void setScore(int new_score)
        {
            score = new_score;

            if (scoreText != null)
            {
                scoreText.text = score.ToString();
            }
        }
    }
}