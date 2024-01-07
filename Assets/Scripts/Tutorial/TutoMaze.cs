using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoMaze : MonoBehaviour
{
    public Animator animtut;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("tutoMaze") && PlayerPrefs.GetInt("tutoMaze") == 1) {
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
            if (!PlayerPrefs.HasKey("tutoMaze")) {
                PlayerPrefs.SetInt("tutoMaze", 1);
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
