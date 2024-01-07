using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;

public abstract class Tile : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] protected bool _walkable;
    [SerializeField] public  GameObject _highlight;
    public string TileName;
    [HideInInspector] public Vector2 positon;

    public BaseUnit OccupiedUnit;
    public bool Walkable => _walkable && !OccupiedUnit;
    

    public virtual void Init()
    {
        //_renderer = GetComponent<SpriteRenderer>();
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        _highlight.SetActive(true);
        MenuManager.instance.ShowTileInfo(this);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        _highlight.SetActive(false);
        MenuManager.instance.ShowTileInfo(null);
    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.State != GameManager.GameState.PlayerTurn) return;
        if (OccupiedUnit)
        {
            if (OccupiedUnit.Faction == Faction.Player) UnitManager.Instance.SetSelectedPlayer((BasePlayer)OccupiedUnit);
            else
            {
                if (UnitManager.Instance.SelectedPlayer)
                {
                    BaseNpcs enemy = (BaseNpcs)OccupiedUnit;
                    Debug.Log(new System.Text.StringBuilder("Attack ").Append(enemy.UnitName));
                    UnitManager.Instance.SelectedPlayer.Light.color = enemy.Light.color;
                    Destroy(enemy.gameObject);
                    SetUnit(UnitManager.Instance.SelectedPlayer);
                    UnitManager.Instance.SetSelectedPlayer(null);
                }
            }
        }
        else
        {
            if (UnitManager.Instance.SelectedPlayer)
            {
                if (!Walkable) { 
                    //UnitManager.Instance.SelectedPlayer.Animator.SetTrigger("jiggle");
                    return;
                }
                SetUnit(UnitManager.Instance.SelectedPlayer);
                UnitManager.Instance.SetSelectedPlayer(null);
            }
        }
    }

    public void SetUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }

}
