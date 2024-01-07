using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FindGameMainMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("BodyGame");
    }
    
    public void PlayLevel2()
    {
        SceneManager.LoadScene("FindGame");
    }
    
    public void LoadMap(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}