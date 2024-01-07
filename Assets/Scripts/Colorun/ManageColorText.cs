using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SchoolAdventure.Games.Mathematique.Colorun
{
    public class ManageColorText : MonoBehaviour
    {
        public TextMeshProUGUI colorText;
        private int color = ColorunPlayer.targetColor;
        public static string[] colors = ColorunPlayer.colors;

        void Update()
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                color = ColorunPlayer.targetColor;
                colorText.text = colors[color - 1];
            }
        }
    }
}