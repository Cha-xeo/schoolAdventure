using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Langues.Logo
{
    public class ScoreManagerLogo : MonoBehaviour
    {
        public static ScoreManagerLogo instance;
        public TMP_Text scoreText;
        public static int score = 0;

        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            scoreText.text = score.ToString() + " Point(s)";
        }

        public void addPoint()
        {
            score++;
            if (score == 5) {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(13);
            }
            scoreText.text = score.ToString() + " Point(s)";
        }

        public void removePoint()
        {
            if (score > 0)
                score--;
            scoreText.text = score.ToString() + " Point(s)";
        }
    }
}