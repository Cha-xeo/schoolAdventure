using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Science.ColorSequence
{
    public class ScoreManagerColors : MonoBehaviour
    {
        public static ScoreManagerColors instance;
        public Text scoreText;
        public static int score;

        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            scoreText.text = score.ToString() + " Point(s)";
        }

        public void addThreePoint()
        {
            score = score + 3;
            scoreText.text = score.ToString() + " Point(s)";
        }

        public void addOnePoint()
        {
            score = score + 1;
            scoreText.text = score.ToString() + " Point(s)";
        }
    }
}