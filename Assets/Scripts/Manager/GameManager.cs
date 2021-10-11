using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.generateGrid:
                break;
            case GameState.spawnUnit:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }


    }

    public enum GameState
{
    generateGrid = 0,
    spawnUnit

}
}