using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SymphoQuizMainMenu : MonoBehaviour
{
    public static int level;
    public GameObject HelpPage;

    public void SetLevel(int x)
    {
        level = x;
    }

    public void LoadHelpPage()
    {
        HelpPage.SetActive(true);
    }

    public void CLoseHelpPage()
    {
        HelpPage.SetActive(false);
    }
}
