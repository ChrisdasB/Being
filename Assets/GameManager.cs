using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameStage _gameStage;
    private Turn _turn;

    public static event Action AimTurn;
    public static event Action PowerTurn;
    public static event Action LaunchTurn;

    // Start is called before the first frame update
    private void Awake()
    {
        AimTurn += ActivateAim;
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
        ChangeTurn(Turn.Aim);
    }

    private void ChangeGameState(GameStage _nextGameState)
    {
        _gameStage = _nextGameState;

        if(_gameStage == GameStage.Play) 
        {
            ChangeTurn(Turn.Aim);
            
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
    End
}

public enum Turn
{
    Aim,
    Power,
    Launch
}
