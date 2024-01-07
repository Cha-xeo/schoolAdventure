using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Langues.Quizz
{
    public class SceneChangerLang : MonoBehaviour
    {
        public void toMenu()
        {
            SceneManager.LoadScene("MenuLang");
        }

        public void toQuiz()
        {
            SceneManager.LoadScene("QuizzLangues");
        }
    }
}