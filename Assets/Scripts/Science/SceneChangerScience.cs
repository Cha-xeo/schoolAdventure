using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Science.ZouzouSnake
{
    public class SceneChangerScience : MonoBehaviour
    {
        public void toGame()
        {
            ScoreManagerSc.score = 0;
            SceneManager.LoadScene("Snake");
        }
    }
}
