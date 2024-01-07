using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Geometrie
{
    public class SceneChange : MonoBehaviour
    {
        public void toSquare()
        {
            SceneManager.LoadScene("LevelTwoScene");
        }

        public void toCircle()
        {
            SceneManager.LoadScene("LevelThreeScene");
        }

        public void toTriangle()
        {
            SceneManager.LoadScene("LevelOneScene");
        }

        public void toMenu()
        {
            SceneManager.LoadScene("MenuGeometry");
            ScoreManagerGeometry.score = 0;
        }

        public void toLeave()
        {
            SceneManager.LoadScene("GameSelection");
        }
    }
}
