using SchoolAdventure.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Vector3 _pos;
    Collider2D jpp;
    [SerializeField] GridManager _gridManager;
    Tile _activeTile;
    void Start()
    {
    }
    private void Update()
    {
        if (InputManager.GetInstance().GetLeftMousePressed())
        {
            jpp = Physics2D.OverlapPoint(InputManager.GetInstance().GetMousePosition());
            if (jpp)
            {
                _activeTile = jpp.GetComponent<Tile>();
            }    
        }
    }
}
