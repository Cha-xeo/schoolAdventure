using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutoQuizzLangues : MonoBehaviour
{
    public Animator animtut;
    public SchoolAdventure.Games.Langues.Quizz.TimeManagerLang quizzScript;
    public bool tuto = false;

    // Start is called before the first frame update
    void Start()
    {
        /*if (PlayerPrefs.HasKey("tutoQuizzLangues") && PlayerPrefs.GetInt("tutoQuizzLangues") == 1) {
            gameObject.SetActive(false);
        }*/
        tuto = true;
        animtut = GetComponent<Animator>();
    }

    // Update is called once per frame
    void ChangeAnimation()
    {
        animtut.SetInteger("Change", animtut.GetInteger("Change") + 1);
        if (animtut.GetInteger("Change") > 3) {
            tuto = false;
            //gameObject.SetActive(false);
            if (!PlayerPrefs.HasKey("tutoQuizzLangues")) {
                PlayerPrefs.SetInt("tutoQuizzLangues", 1);
            }
        }   
    }
    void Update()
    {
        if (InputManager.GetInstance().GetAnyKeyPressed() || InputManager.GetInstance().GetRightMousePressed() || InputManager.GetInstance().GetLeftMousePressed())
        {
            ChangeAnimation();
        }
        
    }
}