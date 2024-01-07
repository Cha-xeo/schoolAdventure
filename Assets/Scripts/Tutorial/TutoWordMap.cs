using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutoWordMap : MonoBehaviour
{
    public Animator animtut;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("tutoWordMap") && PlayerPrefs.GetInt("tutoWordMap") == 1) {
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
            if (!PlayerPrefs.HasKey("tutoWordMap")) {
                PlayerPrefs.SetInt("tutoWordMap", 1);
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