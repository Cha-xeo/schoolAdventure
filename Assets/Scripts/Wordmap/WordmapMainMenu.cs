using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordmapMainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("WordmapSelect");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("GameSelection");
    }
}
