using SchoolAdventure.Games.Lab.Dialogue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Lab.Player
{
    public class LabPlayerController : MonoBehaviour
    {
        public float moveSpeed = 6f;
        public Animator anime;
        private Rigidbody2D rb;
        Vector2 moveInput;
        Vector2 _lookDirection = new Vector2(1, 0);


        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {

            if (LabDialogueManager.GetInstance().dialogueIsPlaying) return;
            moveInput = InputManager.GetInstance().GetMoveDirection();
            if (!Mathf.Approximately(moveInput.x, 0.0f) || !Mathf.Approximately(moveInput.y, 0.0f))
            {
                _lookDirection = moveInput.normalized;
            }
            anime.SetFloat("Horizontal", _lookDirection.x);
            anime.SetFloat("Vertical", _lookDirection.y);
            anime.SetFloat("Magnitude", moveInput.magnitude);
        }
        private void FixedUpdate()
        {
            if (LabDialogueManager.GetInstance().dialogueIsPlaying) return;
            handleMov();

        }

        private void handleMov()
        {
            rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        }
    }
}