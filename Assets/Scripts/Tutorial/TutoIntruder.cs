using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutoIntruder : MonoBehaviour
{
    public Animator animtut;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("tutoIntruder") && PlayerPrefs.GetInt("tutoIntruder") == 1) {
            gameObject.SetActive(false);
        }
        animtut = GetComponent<Animator>();
    }

    void ChangeAnimation()
    {
        animtut.SetInteger("Change", animtut.GetInteger("Change") + 1);
        if (animtut.GetInteger("Change") > 5) {
            //gameObject.SetActive(false);
            if (!PlayerPrefs.HasKey("tutoIntruder")) {
                PlayerPrefs.SetInt("tutoIntruder", 1);
            }
        }   
    }
    // Update is called once per frame
    void Update()
    {
        if (InputManager.GetInstance().GetAnyKeyPressed() || InputManager.GetInstance().GetRightMousePressed() || InputManager.GetInstance().GetLeftMousePressed())
        {
            ChangeAnimation();
        }
    }
}
