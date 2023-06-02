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
    }

    private void ManagePlayState()
    {
        print("Deactivating all UI!");
        gameOverContainer.SetActive(false);
        winContainer.SetActive(false);
        pauseContainer.SetActive(false);
    }

    private void ManagePauseState()
    {
        pauseContainer.SetActive(true);
    }

    private void Start()
    {
        GameManager.LaunchTurn += UpdateTries;
        GameManager.EndStage += ManageEndState;
        GameManager.WinStage += ManageWinState;
        UpdateTries();
    }

    void ManageEndState()
    {
        gameOverContainer.SetActive(true);
    }

    void ManageWinState()
    {
        winContainer.SetActive(true);
    }

    void UpdateTries()
    {
        triesCount.text = DataManagerSingleton.Instance.triesCount.ToString();
    }
}
