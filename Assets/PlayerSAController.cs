using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSAController : MonoBehaviour
{
    public float MoveSpeed = 6f;
    public Animator Anime;
    [SerializeField] Rigidbody2D _rb;
    Vector2 _moveInput;
    Vector2 _lookDirection = new Vector2(1, 0);

    public enum GameType
    {
        Undifined,
        SideScroller,
        TopDown,
    }

    public GameType Type;
    bool _flip = false;

    private void Update()
    {
        _moveInput = InputManager.GetInstance().GetMoveDirection();
        switch (Type)
        {
            case GameType.Undifined:
                break;
            case GameType.SideScroller:
                break;
            case GameType.TopDown:
                if (_moveInput.x > 0.0f && _flip)
                {
                    changeDirection();
                }
                if (_moveInput.x < 0.0f && !_flip)
                {
                    changeDirection();
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        if (!Mathf.Approximately(_moveInput.x, 0.0f) || !Mathf.Approximately(_moveInput.y, 0.0f))
        {
            _lookDirection = _moveInput.normalized;
        }
        switch (Type)
        {
            case GameType.Undifined:
                break;
            case GameType.SideScroller:
                break;
            case GameType.TopDown:
                //_rb.velocity = _moveInput;
                _rb.MovePosition(_rb.position + _moveInput * MoveSpeed * Time.fixedDeltaTime);
                Anime.SetFloat("Speed", Mathf.Abs(_moveInput.x));
        break;
        }
    }

    private void changeDirection()
    {
        Vector3 tempScale = transform.localScale;
        // you code here. Use direction param
        tempScale.x *= -1;
        transform.localScale = tempScale;
        _flip = !_flip;
    }
}
