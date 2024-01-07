using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordmapGameOverPopup : MonoBehaviour
{
    public GameObject gameOverPopup;
    public GameObject continueGameAfterAdsButton;   

    void Start()
    {
        continueGameAfterAdsButton.GetComponent<Button>().interactable = true;
        gameOverPopup.SetActive(false);

        WordmapGameEvents.OnGameOver += ShowGameOverPopup;
    }

    private void OnDisable()
    {
        WordmapGameEvents.OnGameOver -= ShowGameOverPopup;
    }

    private void ShowGameOverPopup()
    {
        gameOverPopup.SetActive(true);
        //continueGameAfterAdsButton.GetComponent<Button>().interactable = false;
    }
}
