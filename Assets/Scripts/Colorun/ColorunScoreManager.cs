using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SchoolAdventure.Games.Mathematique.Colorun
{
    public class ColorunScoreManager : MonoBehaviour
    {

        public TextMeshProUGUI scoreText;
        public float score;

        void Update()
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                //score += 1 * Time.deltaTime;
                score = ColorunPlayer.score;
                scoreText.text = "Score : " + ((int)score).ToString();
            }
        }
    }
}