using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Tile OccupiedTile;
    public Faction Faction;
    public Animator Animator;
    public Light2D Light;
    MaterialPropertyBlock _materialPropertyBlock;
    SpriteRenderer _renderer;
    protected virtual void Awake()
    {
        Light = GetComponent<Light2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _materialPropertyBlock = new MaterialPropertyBlock();
    }

    protected Color GetRandomColor()
    {
        return new Color(
            Random.Range(0f,1f),
            Random.Range(0f,1f),
            Random.Range(0f,1f)
        );
    }

    protected virtual void ChangeColor()
    {
        Color color = GetRandomColor();
        _renderer.GetPropertyBlock( _materialPropertyBlock );
        _materialPropertyBlock.SetColor("_Color", color);
        _renderer.SetPropertyBlock( _materialPropertyBlock );
        _renderer.color = GetRandomColor();
    }
}
