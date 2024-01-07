using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] GameObject _selectedPlayerObject, _tileObject, _tileUnitObject;
    private void Awake()
    {
        instance = this;
    }

    public void ShowTileInfo(Tile tile)
    {
        if (!tile)
        {
            _tileObject.SetActive(false);
            _tileUnitObject.SetActive(false);
            return;
        }
        _tileObject.GetComponentInChildren<TextMeshProUGUI>().text = tile.TileName;
        _tileObject.SetActive(true);

        if(tile.OccupiedUnit) 
        {
            _tileUnitObject.GetComponentInChildren<TextMeshProUGUI>().text = tile.OccupiedUnit.UnitName;
            _tileUnitObject.SetActive(true);
        }
    }
    public void ShowSelectedPlayer(BasePlayer player)
    { 
        if (!player)
        {
            _selectedPlayerObject.SetActive(false); 
            return;
        }
        _selectedPlayerObject.GetComponentInChildren<TextMeshProUGUI>().text = player.UnitName;
        _selectedPlayerObject.SetActive(true);
    }
}
