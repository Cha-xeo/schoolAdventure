using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SchoolAdventure.Games.Geometrie
{
    public class QuitGame : MonoBehaviour
    {
        public void QuiteGame()
        {
            SceneManager.LoadScene("MenuGeometry");
        }
    }
}
