using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Definition of GameStages
public enum GameStage
{
    Tutorial,
    Pause,
    Start,
    Play,
    End,
    Win
}

// Definition of Play-Stages (Onyl apply, if GameStage is Play)
public enum Turn
{
    Aim,
    Power,
    Launch
}

public class GameManager : MonoBehaviour
{
    [SerializeField] GameStage startingStage;
    [SerializeField] Turn startingTurn;

    private GameStage _gameStage;
    private Turn _turn;

    // Game Stages
    // ToDo: Implement Start and Tutorial events
    public static event Action EndStage;
    public static event Action PauseStage;
    public static event Action WinStage;
    public static event Action PlayStage;
    public static event Action StartStage;
    public static event Action TutorialStage;

    // Play Stages - Only apply when GameStage is Play
    public static event Action AimTurn;
    public static event Action PowerTurn;
    public static event Action LaunchTurn;

    // Operational Events
    public static event Action UpdateTries;


    private void Awake()
    {
        // Event Subs
        TutorialManager.TutorialFinished += TutorialFinished;
        SceneTransitionManager.SceneOpened += StartLevel;

        // GameState Play events
        DangerSurfaceController.PlayerDied += PlayerDied;
        FinishController.TargetHit += TargetHit;
        TriesPowerUpController.IncreaseTries += IncreaseTries;
        LaunchController.LaunchingDone += LaunchingDone;

        // Input Events
        InputManager.EscapeClicked += EscapeClicked;
        InputManager.LeftMouseClicked += MouseLeftClick;
        InputManager.RightMouseClicked += MouseRightClick;
    }

    private void StartLevel()
    {
        ChangeGameState(startingStage);
        ChangeTurn(startingTurn);
    }

    private void TutorialFinished()
    {
        ChangeGameState(GameStage.Play);
        UpdateTries.Invoke();
    }
   

    // INPUT EVENTS //
    // Handle click on escape depending on the GameStage (Pause Menu)
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
    // Handle mouseclick-left depending on the Play-Stage
    public void MouseLeftClick()
    {
        if (_turn == Turn.Aim)
        {
            ChangeTurn(Turn.Power);
        }
        else if (_turn == Turn.Power)
        {
            ChangeTurn(Turn.Launch);
        }
    }
    // Handle mouseclick-right depending on the Play-Stage
    public void MouseRightClick()
    {
        if (_turn == Turn.Power)
        {
            ChangeTurn(Turn.Aim);
        }
    }


    // PLAY-STAGE EVENTS //
    // If player hits a Tries-PowerUp, increase triesCount by 3 (for now), Invoke event
    private void IncreaseTries()
    {
        DataManagerSingleton.Instance.triesCount += 3;
        //UpdateTries.Invoke();
    }
        

    // Event fired after launching and player comes to a stop: Check for tries-counter and change Game-Stage depended on that
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

    // If player hits the target, change Game-Stage to Win
    public void TargetHit()
    {
        ChangeGameState(GameStage.Win);
    }

    // If play hit a dangerous barrier, change Game-Stage to End
    public void PlayerDied()
    {
        ChangeGameState(GameStage.End);
    }

    // Game-Stage controller
    private void ChangeGameState(GameStage _nextGameState)
    {
        // If player has already won, ignore incoming changes (In case the player hits something else or has 0 tries left after winning)
        if(_gameStage != GameStage.Win)
        {
            _gameStage = _nextGameState;
        }
        else
        {
            return;
        }

        // Game-Stage Play: Set Play-Stage to Aim (which is the first Stage), Set Time to 1 (In case Pause was active before), Invoke PlayStage-Event
        if(_gameStage == GameStage.Play) 
        {
            Time.timeScale = 1;
            ChangeTurn(Turn.Aim);
            PlayStage.Invoke();
        }
        // GameStage End: Invoke event
        else if(_gameStage == GameStage.End)
        {
            EndStage.Invoke();
        }
        // GameStage Win: Invoke event
        else if (_gameStage == GameStage.Win)
        {
            WinStage.Invoke();
        }
        // GameStage End: Set Timt to 0, invoke event
        else if (_gameStage == GameStage.Pause)
        {
            Time.timeScale = 0;
            PauseStage.Invoke();
        }
        else if (_gameStage == GameStage.Start)
        {
            Time.timeScale = 0;
            StartStage.Invoke();
        }
        else if(_gameStage == GameStage.Tutorial)
        {
            Time.timeScale = 1;
            TutorialStage.Invoke();
        }
    }

    // Play-Stage controller (Aim -> Power -> Launch) - Only aaplies, when GameStage is Play, on launch state: Lower triesCount by one
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
                LaunchTurn.Invoke();
            }            
        }
    }
}