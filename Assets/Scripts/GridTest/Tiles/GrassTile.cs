using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile
{
    [SerializeField] private Color _baseColor, _offsetColor;

    public override void Init()
    {
        _walkable = true;
        _renderer.color = (positon.x + positon.y) % 2 == 1 ? _offsetColor : _baseColor;
    }
}
