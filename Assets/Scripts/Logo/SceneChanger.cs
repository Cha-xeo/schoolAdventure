using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Langues.Logo
{
    public class SceneChanger : MonoBehaviour
    {
        public void toGame()
        {
            ScoreManagerLogo.score = 0;
            SceneManager.LoadScene("GameLogo");
        }

        public void toLeave()
        {
            ScoreManagerLogo.score = 0;
            Application.Quit();
        }
    }
}