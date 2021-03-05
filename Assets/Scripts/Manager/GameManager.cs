using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    NarrativeScene,
    BossFight,    
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private GameState _currentGameState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { 
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        switch (_currentGameState)
        {
            case GameState.NarrativeScene:
                break;
            case GameState.BossFight:
                break;
        }


    }
}