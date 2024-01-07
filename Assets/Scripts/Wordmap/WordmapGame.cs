using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordmapGame : MonoBehaviour
{
    public void LoadMap(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
