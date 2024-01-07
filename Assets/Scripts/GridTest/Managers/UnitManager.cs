using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    
    List<ScriptableUnit> _unitList;
    BasePlayer p1Prefab;
    public BasePlayer SelectedPlayer;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _npcs;
    List<BaseNpcs> _listNpcs = new List<BaseNpcs>();
    Tile p1SpawnTile;

    private void Awake()
    {
        Instance = this;
        _unitList = Resources.LoadAll<ScriptableUnit>("GridTest/Units").ToList();
    }

    public void SpawnPlayer(Faction faction)
    {
        if (faction == Faction.Player)
        {
            p1Prefab = Instantiate(GetRandomUnit<BasePlayer>(Faction.Player), _player);
            p1SpawnTile = GridManager.Instance.GetSpawnTile(Faction.Player);
            p1SpawnTile.SetUnit(p1Prefab);
            GameManager.Instance.UpdateGameState(GameManager.GameState.SpawnNPCS);
            return;
        }
        _listNpcs.Add(Instantiate(GetRandomUnit<BaseNpcs>(Faction.Enemy), _npcs));
        GridManager.Instance.GetSpawnTile(Faction.Enemy).SetUnit(_listNpcs.Last());
        _listNpcs.Add(Instantiate(GetRandomUnit<BaseNpcs>(Faction.Enemy), _npcs));
        GridManager.Instance.GetSpawnTile(Faction.Enemy).SetUnit(_listNpcs.Last());
        _listNpcs.Add(Instantiate(GetRandomUnit<BaseNpcs>(Faction.Enemy), _npcs));
        GridManager.Instance.GetSpawnTile(Faction.Enemy).SetUnit(_listNpcs.Last());
        GameManager.Instance.UpdateGameState(GameManager.GameState.PlayerTurn);
        return;
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)_unitList.Where(u=>u.Faction == faction).OrderBy(o=>Random.value).First().unitPrefab;
    }

    public void SetSelectedPlayer(BasePlayer player)
    {
        SelectedPlayer = player;
        MenuManager.instance.ShowSelectedPlayer(player);
    }
}
