using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Geographie.ZouzouGeo
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager instance;
        public TMP_Text scoreText;
        public static int score = 0;

        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            scoreText.text = score.ToString();
        }

        void Update()
        {

        }

        public void addPoint()
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}