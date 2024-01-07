using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGameManager : MonoBehaviour
{
    public static HexGameManager Instance;
    public HexGameState State;

    public static event Action<HexGameState> StateChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(HexGameState.GenerateGrid);
    }

    public void UpdateGameState(HexGameState newState)
    {
        State = newState;
        switch (newState)
        {
            case HexGameState.GenerateGrid:
                HexGridManager.Instance.GenerateHexGrid();
                break;
            case HexGameState.GenerateOverlay:
                HexGridManager.Instance.GenerateHexOverlay();
                break;
            case HexGameState.Play:
                break;
            default:
                break;
        }
    }

    public enum HexGameState
    {
        GenerateOverlay,
        GenerateGrid,
        Play,
    }
}
