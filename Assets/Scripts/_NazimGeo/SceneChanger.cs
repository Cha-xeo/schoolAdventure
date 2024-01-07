using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Geographie.ZouzouGeo
{
    public class SceneChanger : MonoBehaviour
    {
        public void toAfrica()
        {
            ScoreManager.score = 0;
            TimeManager.TimeLeft = 25;
            SceneManager.LoadScene("Africa");
        }

        public void toEurope()
        {
            ScoreManager.score = 0;
            TimeManager.TimeLeft = 25;
            SceneManager.LoadScene("Europe");
        }

        public void toAmerica()
        {
            ScoreManager.score = 0;
            TimeManager.TimeLeft = 25;
            SceneManager.LoadScene("America");
        }

        public void toAsia()
        {
            ScoreManager.score = 0;
            TimeManager.TimeLeft = 25;
            SceneManager.LoadScene("Asia");
        }

        public void toMenu()
        {
            ScoreManager.score = 0;
            TimeManager.TimeLeft = 25;
            SceneManager.LoadScene("Menu");
        }

        public void toLeave()
        {
            //Application.Quit();
            SceneManager.LoadScene("GameSelection");
        }
    }
}
