using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Langues.Pendu
{
    public class SceneManagerFrench : MonoBehaviour
    {
        public void toGame()
        {
            ScoreManagerFrench.score = 0;
            SceneManager.LoadScene("GameFr");
        }


        public void toMenu()
        {
            SceneManager.LoadScene("MenuFr");
        }

        /*public void toLeave()
        {
            Application.Quit();
        }*/
    }
}