using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SchoolAdventure.Games.Mathematique.Colorun
{
    public class GameOverScore : MonoBehaviour
    {

        public TextMeshProUGUI scoreText;
        public float score;

        void Update()
        {
            score = ColorunPlayer.score;
            scoreText.text = "Your score : " + ((int)score).ToString();
        }
    }
}