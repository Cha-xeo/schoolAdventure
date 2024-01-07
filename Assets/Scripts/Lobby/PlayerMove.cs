// using System.Collections;
// using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float MovementSpeed;

	// Use this for initialization
	void Start () {
        // rb.MovePosition(new Vector2(3, 2));
	}

	// Update is called once per frame
	void Update () {
        Vector2 moveInput = InputManager.GetInstance().GetMoveDirection();
        if (InputManager.GetInstance().GetEscapePressed()) {
            Application.Quit();
        }

        /*if (movement != 0 || movement2 != 0)
            animator.SetBool("IsRunning", true);
        else
            animator.SetBool("IsRunning", false);*/
        rb.velocity = new Vector3(moveInput.x , moveInput.y , 0);
        transform.position += new Vector3(moveInput.x, moveInput.y, 0) * Time.deltaTime * MovementSpeed;
	}



    void OnTriggerStay2D(Collider2D collider)
    {
        // Debug.Log("Collider2D " + col.gameObject.tag);
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
       
    }
}
