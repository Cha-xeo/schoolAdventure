using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    public static event Action<GameState> StateChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.GenerateGrid);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.Select:
                break;
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnPlayer:
                UnitManager.Instance.SpawnPlayer(Faction.Player);
                break;
            case GameState.SpawnNPCS:
                UnitManager.Instance.SpawnPlayer(Faction.Enemy);
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.NPCSTurn:
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
            default:
                break;
        }
    }

    public enum GameState
    {
        Select,
        GenerateGrid,
        SpawnPlayer,
        SpawnNPCS,
        PlayerTurn,
        NPCSTurn,
        Victory,
        Lose
    }
}
