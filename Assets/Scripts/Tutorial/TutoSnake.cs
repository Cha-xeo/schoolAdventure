using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoSnake : MonoBehaviour
{
    public Animator animtut;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("tutoSnake") && PlayerPrefs.GetInt("tutoSnake") == 1) {
            gameObject.SetActive(false);
        }
        animtut = GetComponent<Animator>();
    }

    // Update is called once per frame
    void ChangeAnimation()
    {
        animtut.SetInteger("Change", animtut.GetInteger("Change") + 1);
        if (animtut.GetInteger("Change") > 3) {
            //gameObject.SetActive(false);
            if (!PlayerPrefs.HasKey("tutoSnake")) {
                PlayerPrefs.SetInt("tutoSnake", 1);
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
