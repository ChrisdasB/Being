using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalMenuController : MonoBehaviour
{
    // Constant menu controler for the permanent menu, that gets carried on from the first scene
    

    [SerializeField] GameObject globalCanvas;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject newGamePanel;
    [SerializeField] GameObject exitPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject confirmMenuPanel;

    bool menuFlag = false;

    private void Awake()
    {
        MySceneManager.SceneIsLoaded += InitMenu;
        GameManager.PauseStage += OpenPauseMenu;
        GameManager.PlayStage += ClosePauseMenu;
        RestartLevel.LevelRestart += ClosePauseMenu;
        BackToMenu.SetMenuFlag += SetMenuFlag;        
        
        InitMenu();
    }

    private void SetMenuFlag()
    {
        menuFlag = true;
    }

    private void OnDestroy()
    {
        MySceneManager.SceneIsLoaded -= InitMenu;
        GameManager.PauseStage -= ClosePauseMenu;
        GameManager.PlayStage -= ClosePauseMenu;
        RestartLevel.LevelRestart -= ClosePauseMenu;
    }

    private void ClosePauseMenu()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        newGamePanel.SetActive(false);
        exitPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        globalCanvas.SetActive(false);
        confirmMenuPanel.SetActive(false);
    }

    private void OpenPauseMenu()
    {
            globalCanvas.SetActive(true);
            pausePanel.SetActive(true);
            optionsPanel.SetActive(false);
            newGamePanel.SetActive(false);
            exitPanel.SetActive(false);
            mainMenuPanel.SetActive(false);
            confirmMenuPanel.SetActive(false);
    }

    

    private void InitMenu()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 9)
        {
            optionsPanel.SetActive(false);
            newGamePanel.SetActive(false);
            exitPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
            pausePanel.SetActive(false);
            confirmMenuPanel.SetActive(false);
        }
        else 
        {
            mainMenuPanel.SetActive(false);
            optionsPanel.SetActive(false);
            newGamePanel.SetActive(false);
            exitPanel.SetActive(false);
            pausePanel.SetActive(false);
            confirmMenuPanel.SetActive(false);
        }
    }
}
