using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text triesCount;
    [SerializeField] GameObject gameOverContainer;
    [SerializeField] GameObject winContainer;
    [SerializeField] GameObject pauseContainer;

    private void Awake()
    {
        //Event Subs
        GameManager.UpdateTries += UpdateTries;
        GameManager.PauseStage += ManagePauseState;
        GameManager.PlayStage += ManagePlayState;
        GameManager.LaunchTurn += UpdateTries;
        GameManager.EndStage += ManageEndState;
        GameManager.WinStage += ManageWinState;
    }

    private void Start()
    {        
        // Set triesText to initial value
        UpdateTries();
    }

    // Deactivate all UI Elements for Play-Stage
    private void ManagePlayState()
    {
        gameOverContainer.SetActive(false);
        winContainer.SetActive(false);
        pauseContainer.SetActive(false);
    }

    // Activate pause menu
    private void ManagePauseState()
    {
        pauseContainer.SetActive(true);
    }

    // Activate GameOver screen
    void ManageEndState()
    {
        gameOverContainer.SetActive(true);
    }

    // Activate Win Screen
    void ManageWinState()
    {
        winContainer.SetActive(true);
    }

    // Update TriesText by value saved in the DataManager
    void UpdateTries()
    {
        triesCount.text = DataManagerSingleton.Instance.triesCount.ToString();
    }
}
