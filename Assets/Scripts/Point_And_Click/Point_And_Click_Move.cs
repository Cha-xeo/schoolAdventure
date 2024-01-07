using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Point_And_Click_Move : MonoBehaviour
{
    public float speed = 10f;

    private Vector2 lastPosMouse;
	
    bool moving;
    public GameObject dialogBox;
    public bool dialogActive;

    public GameObject dialogBox1;
    public bool dialogActive1;

    public GameObject dialogBox2;
    public bool dialogActive2;


    private void Update()
    {

        // envent sur la souris
        
        if(InputManager.GetInstance().GetSubmitPressed()) UnityEngine.SceneManagement.SceneManager.LoadScene(PlayerPrefs.GetString("_LastScene"));
        
        if ((InputManager.GetInstance().GetLeftMousePressed()) && (dialogActive == false && dialogActive1 == false && dialogActive2 == false))
        {
            // set la camera sur la cible cliker sur l'ecran
            lastPosMouse = InputManager.GetInstance().GetMousePosition();
            moving = true;
        } 
       
        // si il y a event et que le player n'ai pas sur la cible alors il y a mouvement
        if (moving && (Vector2)transform.position != lastPosMouse)
        {
            // vitesse set au temps pour le movement
            float step = speed * Time.deltaTime;
            // set le player a sa nouvelle position
            transform.position = Vector2.MoveTowards(transform.position, lastPosMouse, step);
        }
        if ((dialogActive) && (dialogBox != null))
        {
            Debug.Log("pas destroy1");
            moving = false;
        }
        if ((dialogActive1) && (dialogBox1 != null) && !(dialogActive) && (dialogBox == null))
        {
            Debug.Log("pas destroy2");
            moving = false;
        }
        if ((dialogActive2) && (dialogBox2 != null) && !(dialogActive1) && (dialogBox1 == null))
        {
            Debug.Log("pas destroy3");
            moving = false;
        }
       

        if (dialogBox == null)
        {
            dialogActive = false;
        }
        if (dialogBox1 == null)
        {
            dialogActive1 = false;
        }
        if (dialogBox2 == null)
        {
            dialogActive2 = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("dialogue"))
        {
            dialogActive = true;
            Debug.Log("1");
        }
        if (other.CompareTag("dialogue2"))
        {
            dialogActive1 = true;
            Debug.Log("2");
        }
        if (other.CompareTag("dialogue3"))
        {
            dialogActive2 = true;
            Debug.Log("3");
        }
    }
       
}
   
