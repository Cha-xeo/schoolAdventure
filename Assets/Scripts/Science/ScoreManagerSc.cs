using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Science.ZouzouSnake
{
    public class ScoreManagerSc : MonoBehaviour
    {
        public static ScoreManagerSc instance;
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
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(30);
            } else if (score == 30) {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(31);
            } else if (score == 60) {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(32);
            } else if (score == 100) {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(33);
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
