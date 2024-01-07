using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Histoire
{
    public class ScoreManagerHist : MonoBehaviour
    {
        public static ScoreManagerHist instance;
        public Text scoreText;
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