using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum GameState {
        Placing
        , Playing
        , Gameover
    };
    public GameState currentGameState;


    void Start() {
        currentGameState = GameState.Placing;
    }

    public void SetGameState(GameState newState) {
        currentGameState = newState;
    }
}
