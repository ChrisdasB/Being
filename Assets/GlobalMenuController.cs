using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalMenuController : MonoBehaviour
{
    [SerializeField] GameObject globalCanvas;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject newGamePanel;
    [SerializeField] GameObject exitPanel;
    [SerializeField] GameObject pausePanel;

    private void Awake()
    {
        MySceneManager.SceneIsLoaded += InitMenu;
        GameManager.PauseStage += OpenPauseMenu;
        GameManager.PlayStage += ClosePauseMenu;
        InitMenu();
    }

    private void OnDestroy()
    {
        MySceneManager.SceneIsLoaded -= InitMenu;
        GameManager.PauseStage -= ClosePauseMenu;
        GameManager.PlayStage -= ClosePauseMenu;
    }

    private void ClosePauseMenu()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        newGamePanel.SetActive(false);
        exitPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        globalCanvas.SetActive(false);
    }

    private void OpenPauseMenu()
    {
            globalCanvas.SetActive(true);
            pausePanel.SetActive(true);
            optionsPanel.SetActive(false);
            newGamePanel.SetActive(false);
            exitPanel.SetActive(false);
            mainMenuPanel.SetActive(false);        
    }

    

    private void InitMenu()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            optionsPanel.SetActive(false);
            newGamePanel.SetActive(false);
            exitPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
        else 
        {
            mainMenuPanel.SetActive(false);
            optionsPanel.SetActive(false);
            newGamePanel.SetActive(false);
            exitPanel.SetActive(false); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
