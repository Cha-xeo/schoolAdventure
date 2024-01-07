using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HexGridManager : MonoBehaviour
{
    private static HexGridManager _instance;
    public static HexGridManager Instance { get { return _instance; } }

    public OverlayTile OverlayTilePrefab;
    OverlayTile _overlayTile;
    public Transform OverlayContainer;

    //[SerializeField] Tilemap[] _tileMapArray;
    [SerializeField] Tilemap _tileMapBase;
    Vector3Int _tileLocation;
    Vector3 _cellWorldPosition;

    private void Awake()
    {
        if (_instance && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    public void GenerateHexGrid()
    {
        HexGameManager.Instance.UpdateGameState(HexGameManager.HexGameState.GenerateOverlay);
    }
    public void GenerateHexOverlay()
    {
        //BoundsInt bounds = _tileMapArray[0].cellBounds;
        BoundsInt bounds = _tileMapBase.cellBounds;
        Debug.Log(_tileMapBase.size);

        //looping through all tiles
        for (int z = bounds.max.z; z > bounds.min.z; z--)
        {
            for (int y = bounds.min.y ; y < bounds.max.y; y++)
            {
                for (int x = bounds.min.x; x < bounds.max.x; x++)
                {
                    _tileLocation.Set(x, y, z);
                    if (_tileMapBase.HasTile(_tileLocation))
                    {
                        Debug.Log("HasTile");
                        _overlayTile = Instantiate(OverlayTilePrefab, OverlayContainer);
                        _cellWorldPosition = _tileMapBase.GetCellCenterWorld(_tileLocation);
                        _overlayTile.transform.position.Set(_cellWorldPosition.x, _cellWorldPosition.y, _cellWorldPosition.z);
                    }
                }
            }
        }
        HexGameManager.Instance.UpdateGameState(HexGameManager.HexGameState.Play);
    }
}
