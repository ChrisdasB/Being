using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameStage _gameStage;
    private Turn _turn;

    // Game Stages
    public static event Action EndStage;
    public static event Action PauseStage;
    public static event Action WinStage;
    public static event Action PlayStage;

    // Play Stages
    public static event Action AimTurn;
    public static event Action PowerTurn;
    public static event Action LaunchTurn;

    // Operational Events
    public static event Action UpdateTries;


    // Start is called before the first frame update
    private void Awake()
    {
        AimTurn += ActivateAim;

        // Event Subs
        DangerSurfaceController.PlayerDied += PlayerDied;
        FinishController.TargetHit += TargetHit;
        TriesPowerUpController.IncreaseTries += IncreaseTries;
        InputManager.EscapeClicked += EscapeClicked;
    }

    private void EscapeClicked()
    {
        if(_gameStage == GameStage.Play)
        {
            ChangeGameState(GameStage.Pause);
        }
        else if (_gameStage == GameStage.Pause)
        {
            ChangeGameState(GameStage.Play);
        }
    }

    private void IncreaseTries()
    {
        DataManagerSingleton.Instance.triesCount += 3;
        UpdateTries.Invoke();
    }

    private void ActivateAim()
    {
        _turn = Turn.Aim;
    }

    void Start()
    {
        ChangeGameState(GameStage.Play);        
        AimTurn.Invoke();
    }


    // Update is called once per frame
   
    public void MouseLeftClick()
    {
        if(_turn == Turn.Aim) 
        {
            ChangeTurn(Turn.Power);
        }
        else if (_turn == Turn.Power) 
        {
            ChangeTurn(Turn.Launch);
            print("Triggering Launch!");
        }
    }

    public void MouseRightClick()
    {
        if (_turn == Turn.Power)
        {
            ChangeTurn(Turn.Aim);
        }        
    }

    public void LaunchingDone()
    {
        if(DataManagerSingleton.Instance.triesCount <= 0)
        {
            ChangeGameState(GameStage.End);
        }
        else
        {
            ChangeTurn(Turn.Aim);
        }        
    }

    public void TargetHit()
    {
        ChangeGameState(GameStage.Win);
    }

    public void PlayerDied()
    {
        ChangeGameState(GameStage.End);
    }

    private void ChangeGameState(GameStage _nextGameState)
    {
        if(_gameStage != GameStage.Win)
        {
            _gameStage = _nextGameState;
        }
        else
        {
            return;
        }

        if(_gameStage == GameStage.Play) 
        {
            Time.timeScale = 1;
            ChangeTurn(Turn.Aim);
            PlayStage.Invoke();
        }
        else if(_gameStage == GameStage.End)
        {
            EndStage.Invoke();
        }
        else if (_gameStage == GameStage.Win)
        {
            WinStage.Invoke();
        }
        else if(_gameStage == GameStage.Pause)
        {
            Time.timeScale = 0;
            PauseStage.Invoke();
        }
    }

    private void ChangeTurn(Turn _nextTurn)
    {
        if(_gameStage == GameStage.Play)
        {
            _turn = _nextTurn;

            if (_turn == Turn.Aim)
            {
                AimTurn.Invoke();
            }
            else if (_turn == Turn.Power)
            {
                PowerTurn.Invoke();
            }
            else if( _turn == Turn.Launch)
            {
                DataManagerSingleton.Instance.triesCount--;
                print("Counter lowered!");
                LaunchTurn.Invoke();
            }
            
        }
    }
}

public enum GameStage {
    Tutorial,
    Pause,
    Start,
    Play,
    End,
    Win
}

public enum Turn
{
    Aim,
    Power,
    Launch
}
