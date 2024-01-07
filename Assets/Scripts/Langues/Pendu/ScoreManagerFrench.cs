using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Langues.Pendu
{
    public class ScoreManagerFrench : MonoBehaviour
    {
        public static ScoreManagerFrench instance;
        public TMP_Text scoreText;
        public static int score = 0;

        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            //scoreText.text = score.ToString() + " Mot(s)";
        }

        public void addPoint()
        {
            score++;
            if (score == 5) {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(19);
            }
        }
    }
}