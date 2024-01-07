using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutoPendu : MonoBehaviour
{
    public Animator animtut;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("tutoPendu") && PlayerPrefs.GetInt("tutoPendu") == 1) {
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
            if (!PlayerPrefs.HasKey("tutoPendu")) {
                PlayerPrefs.SetInt("tutoPendu", 1);
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