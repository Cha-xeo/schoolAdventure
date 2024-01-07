using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SchoolAdventure.AplicationController;
using SchoolAdventure.UI;


public class ReturnToLobby : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void Quit()
    {
        SchoolAdventure.Audio.SoundManagerV2.Instance.StopAllSounds();
        SceneManager.LoadScene("Open");
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        //AplicationController.AplicationController.Instance.gameIsPaused = true;
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
       // AplicationController.AplicationController.Instance.gameIsPaused = false;
        Time.timeScale = 1;
    }
}
