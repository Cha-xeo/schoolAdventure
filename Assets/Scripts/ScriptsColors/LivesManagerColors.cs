using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Science.ColorSequence
{
    public class LivesManagerColors : MonoBehaviour
    {
        public static LivesManagerColors instance;
        public Text livesText;
        public static int lives;

        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            livesText.text = lives.ToString() + " Vie(s)";
        }

        void Update()
        {

        }

        public void removeLife()
        {
            if (lives == 1)
                SceneManager.LoadScene("EndMenuColors");
            if (lives > 0)
                lives--;
            livesText.text = lives.ToString() + " Vie(s)";
        }
    }
}