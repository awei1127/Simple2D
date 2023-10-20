using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Exploring,
    Dialogue,
    Selecting,
    Paused
}

public class GameDirector : MonoBehaviour
{
    public GameState currentState;

    void Start()
    {
        SetGameState(GameState.Exploring);
    }

    public void SetGameState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.Exploring:
                Debug.Log("已經切換到探索狀態");
                break;
            case GameState.Dialogue:
                Debug.Log("已經切換到對話狀態");
                break;
            case GameState.Selecting:
                Debug.Log("已經切換到選擇狀態");
                break;
            case GameState.Paused:
                Debug.Log("已經切換到暫停狀態");
                break;
            default:
                Debug.Log("目前不在任何狀態中");
                break;
        }
    }
}
