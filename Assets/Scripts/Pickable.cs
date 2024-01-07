using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pickable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] GameObject _player;
    MaterialPropertyBlock _materialPropertyBlock;
    [SerializeField] Collider2D _polygonCollider;
    bool _zoomies = false;
    bool _interactable = false;
    bool _grabbed = false;
    Vector3 _tempScale;
    private void Awake()
    {
        _materialPropertyBlock = new MaterialPropertyBlock();
    }

    private void Update()
    {
        //if (_zoomies)
        //{
        //    ChangeColor();
        //}
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        //_zoomies = true;
        /*if (_interactable)
        {
            ChangeFixdColor(Color.black);
        }*/
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        //_zoomies = false;
        /*if (_interactable)
        {
            ChangeFixdColor(Color.white);
        }*/
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (InputManager.GetInstance().GetShiftPressed())
        {
            Debug.Log("ouio");
            _zoomies = !_zoomies;
            if (_zoomies)
            {
                transform.parent = _player.transform.GetChild(0);
                _grabbed = true;
                _tempScale = transform.localScale;
                _tempScale.x *= 0.5f;
                _tempScale.y *= 0.5f;
                transform.localScale = _tempScale;
            }
            else
            {
                _tempScale = transform.localScale;
                _tempScale.x += _tempScale.x;
                _tempScale.y += _tempScale.y;
                _grabbed = false;
                transform.localScale = _tempScale;
                transform.parent = null;
            }
        }
    }*/

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (_interactable)
        {
            _zoomies = !_zoomies;
            if (_zoomies)
            {
                _polygonCollider.tag = "Untagged";
                transform.parent = _player.transform;
                transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);
                _grabbed = true;
                /*_tempScale = transform.localScale;
                _tempScale.x *= 0.5f;
                _tempScale.y *= 0.5f;
                transform.localScale = _tempScale;*/
            }
            else
            {
                transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, 0);
                _polygonCollider.tag = Constants.TAG_MATCHINGZONE;

                /*_tempScale = transform.localScale;
                _tempScale.x += _tempScale.x;
                _tempScale.y += _tempScale.y;
                transform.localScale = _tempScale;*/
                transform.parent = null;
            }
        }
    }

    private Color GetRandomColor()
    {
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
    }

    private void ChangeColor()
    {
        Color color = GetRandomColor();
        _renderer.GetPropertyBlock(_materialPropertyBlock);
        _materialPropertyBlock.SetColor("_Color", color);
        _renderer.SetPropertyBlock(_materialPropertyBlock);
    }
    private void ChangeFixdColor(Color color)
    {
        _renderer.GetPropertyBlock(_materialPropertyBlock);
        _materialPropertyBlock.SetColor("_Color", color);
        _renderer.SetPropertyBlock(_materialPropertyBlock);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.TAG_PLAYER))
        {
            _interactable = true;
            _player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.TAG_PLAYER) && !_grabbed)
        {
            _interactable = false;
            _player = null;
        }
    }
}