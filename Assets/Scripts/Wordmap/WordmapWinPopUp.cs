using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordmapWinPopUp : MonoBehaviour
{
    public GameObject winPopup;

    void Start()
    {
        winPopup.SetActive(false);
    }

    private void OnEnable()
    {
        WordmapGameEvents.OnBoardCompleted += ShowWinPopup;
    }

    private void OnDisable()
    {
        WordmapGameEvents.OnBoardCompleted -= ShowWinPopup;
    }

    private void ShowWinPopup()
    {
        winPopup.SetActive(true);
    }

    public void LoadNextLevel()
    {
        WordmapGameEvents.LoadNextLevelMethod();
    }
}
