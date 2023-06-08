using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    // Attached to the continue button in main menu
    // Triggers event to load last saved scene
    // Deactivates, if we only have an empty save object
    public static event Action OnContinue;

    Button button;
    bool firstLoaded = false;
    private void Awake()
    {
        button = GetComponent<Button>();
        DataManagerSingleton.DataLoaded += UpdateContinueButton;
        button.onClick.AddListener(ContinueGame);
    }

    private void Start()
    {
        UpdateContinueButton();
    }

    private void OnDestroy()
    {
        DataManagerSingleton.DataLoaded -= UpdateContinueButton;
    }

    private void ContinueGame()
    {        
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
        print("PlayerName Loaded: " + DataManagerSingleton.savedData.playerName);
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
