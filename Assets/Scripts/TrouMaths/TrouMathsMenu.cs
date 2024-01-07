using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrouMathsMenu : MonoBehaviour
{
    public static int level = 1;

    public void LoadMap(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel1(string sceneName)
    {
        level = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadLevel2(string sceneName)
    {
        level = 2;
        SceneManager.LoadScene(sceneName);
    }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
}
