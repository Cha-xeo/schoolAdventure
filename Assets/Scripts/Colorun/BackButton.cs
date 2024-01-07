using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Mathematique.Colorun
{
    public class BackButton : MonoBehaviour
    {
        public void BackMenu()
        {
            SceneManager.LoadScene("MenuColorun");
        }
    }
}
