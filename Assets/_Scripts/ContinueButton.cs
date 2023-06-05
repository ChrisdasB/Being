using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    public static event Action OnContinue;

    Button button;
    bool firstLoaded = false;
    private void Awake()
    {
        button = GetComponent<Button>();
        DataManagerSingleton.DataLoaded += UpdateContinueButton;
        button.onClick.AddListener(ContinueGame);
    }

    private void ContinueGame()
    {
        DataManagerSingleton.savedData.unlockedLevels = 1;
        OnContinue.Invoke();
    }

    private void OnEnable()
    {
        if (firstLoaded)
        {
            UpdateContinueButton();
        }

    }

    private void UpdateContinueButton()
    {
        if(DataManagerSingleton.savedData.playerName != "") 
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
        firstLoaded = true;
    }
}
