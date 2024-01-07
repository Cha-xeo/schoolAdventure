using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Maze
{
    public class SceneChangerMaze : MonoBehaviour
    {
        public void toLvlOne()
        {
            SceneManager.LoadScene("Maze");
        }

        public void toLvlTwo()
        {
            SceneManager.LoadScene("MazeTwo");
        }

        public void toLvlThree()
        {
            SceneManager.LoadScene("MazeThree");
        }

        public void toMenu()
        {
            SceneManager.LoadScene("MazeMenu");
        }
    }
}