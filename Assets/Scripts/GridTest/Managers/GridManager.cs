using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [SerializeField] private int _width, _height;
    [SerializeField] private Transform _world;
    [SerializeField] private Tile[] _tilesArray;
    Tile _spawnedTile;

    [SerializeField] private Transform _cam;
    [SerializeField] private bool _isHex = false;
    bool odd = false;

    private Dictionary<Vector2, Tile> _tiles;

    private void Awake()
    {
        Instance = this;
    }
    public void GenerateGrid()
    {
        if (_isHex)
        {
            _tiles = new Dictionary<Vector2, Tile>();
            for (float y = 0; y < _height; y += 0.569f, odd = !odd)
            {
                for (float x = 0; x < _width; x+= 0.759f)
                {
                    // TODO Add biome logic
                    _spawnedTile = Instantiate(Random.Range(0, 6) == 3 ? _tilesArray[1] : _tilesArray[0], new Vector3(odd ? x + 0.379f : x, y), Quaternion.identity, _world);
                    _spawnedTile.positon = _spawnedTile.transform.position;
                    _spawnedTile.Init();
                    _tiles[_spawnedTile.positon] = _spawnedTile;
                }
            }
            _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
            GameManager.Instance.UpdateGameState(GameManager.GameState.SpawnPlayer);
            return;
        }
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                // TODO Add biome logic
                //Tile randomTile = Random.Range(0, 6) == 3 ? _mountainTile : _grassTile;
                _spawnedTile = Instantiate(Random.Range(0, 6) == 3 ? _tilesArray[1] : _tilesArray[0], new Vector3(x, y), Quaternion.identity, _world);
                //spawnedTile.name = $"Tile {x} {y}";

                // Avoiding transform.position call
                _spawnedTile.positon.Set(x, y);

                
                _spawnedTile.Init();


                _tiles[_spawnedTile.positon] = _spawnedTile;
            }
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
        GameManager.Instance.UpdateGameState(GameManager.GameState.SpawnPlayer);
    }

    public Tile GetSpawnTile(Faction faction)
    {
        if (faction == Faction.Player) {
            //return _tiles.Where(t => t.Key.x < _width*0.5f && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
            return _tiles.Where(t => t.Key.x < _width/2 && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
        }
        return _tiles.Where(t => t.Key.x > _width*0.5f && t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out Tile tile)) return tile;
        return null;
    }
}