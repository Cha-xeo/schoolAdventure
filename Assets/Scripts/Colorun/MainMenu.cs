using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Mathematique.Colorun
{
    public class MainMenu : MonoBehaviour
    {
        public static int level = 5;

        public void Level1()
        {
            level = 5;
            SceneManager.LoadScene("Colorun");
        }

        public void Level2()
        {
            level = 9;
            SceneManager.LoadScene("Colorun");
        }

        public void Level3()
        {
            level = 13;
            SceneManager.LoadScene("Colorun");
        }

        public void Level4()
        {
            level = 17;
            SceneManager.LoadScene("Colorun");
        }

        public void QuitGame()
        {
            SceneManager.LoadScene("GameSelection");
        }

        public void HelpMenu()
        {
            SceneManager.LoadScene("ColorunHelpWindow");
        }
    }
}
