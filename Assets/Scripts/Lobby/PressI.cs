using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tutoManager;
    void Start()
    {
        if (PlayerPrefs.HasKey("tutoOpenWorld") && PlayerPrefs.GetInt("tutoOpenWorld") == 1) {
            tutoManager.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenDialogueManager.GetInstance().dialogueIsPlaying) {
             tutoManager.SetActive(false);
             if (!PlayerPrefs.HasKey("tutoOpenWorld")) {
                    PlayerPrefs.SetInt("tutoOpenWorld", 1);
            } 
        }
    }
}
