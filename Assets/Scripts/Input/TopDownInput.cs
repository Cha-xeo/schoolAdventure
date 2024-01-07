using System.Xml.Linq;
using UnityEngine;

namespace SchoolAdventure.Input.TopDown
{
    public class TopDownInput : MonoBehaviour
    {
        public float moveSpeed = 6f;
        [HideInInspector] public Vector2 moveInput;
        public Rigidbody2D rb;
        bool HasRigidBody => rb;
        public bool CanMoove = true;
        [SerializeField] Animator _animator;
        bool swaped = false;
        Vector2 _lookDirection = new Vector2(1, 0);

        private void Update()
        {
            if (!CanMoove) return;
            moveInput = InputManager.GetInstance().GetMoveDirection();
            if (_animator)
            {
              /*  if (!Mathf.Approximately(moveInput.x, 0.0f) || !Mathf.Approximately(moveInput.y, 0.0f))
                {
                    _lookDirection = moveInput.normalized;
                }
                _animator.SetFloat("Horizontal", _lookDirection.x);
                _animator.SetFloat("Vertical", _lookDirection.y);
                _animator.SetFloat("Magnitude", moveInput.magnitude);*/
                if (!Mathf.Approximately(moveInput.x, 0.0f))
                {
                    _lookDirection = moveInput.normalized;
                }

                if (moveInput.x == 0.0f && moveInput.y == 0.0f)
                {
                    _animator.SetFloat("SpeedY", _lookDirection.x);
                    _animator.SetFloat("Speed", 0f);
                }
                else
                {
                    _animator.SetFloat("SpeedY", 0);
                    _animator.SetFloat("Speed", _lookDirection.x);
                }
            }
        }

        private void FixedUpdate()
        {
            if (!CanMoove) return;
            if (HasRigidBody)
            {
                rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
                return;
            }
            transform.Translate(moveInput * moveSpeed * Time.deltaTime);
        }
    }
}
