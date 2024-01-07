using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SchoolAdventure.Games.Maze
{
    public class PlayermazeMove : MonoBehaviour
    {

        private Rigidbody2D square;
        //private Player player;
        private Animator animator;
        Vector2 inputVector = Vector2.zero;

        private void Awake()
        {
            square = GetComponent<Rigidbody2D>();
            //player = new Player();
            //player.PlayerMove.Enable();
            animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            float speed = 5.0f;
            inputVector = InputManager.GetInstance().GetMoveDirection();
            transform.Translate((inputVector.x * speed) * Time.deltaTime, (inputVector.y * speed) * Time.deltaTime, 0);
            //transform.Translate((inputVector.x * speed), (inputVector.y * speed), 0);

            if (inputVector.x != 0 || inputVector.y != 0)
            {
                animator.SetFloat("X", inputVector.x);
                animator.SetFloat("Y", inputVector.y);
                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }
        }
    }
}