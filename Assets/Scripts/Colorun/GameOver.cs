using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Mathematique.Colorun
{
    public class GameOver : MonoBehaviour
    {
        public GameObject panel;

        void Update()
        {
            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                panel.SetActive(true);
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}