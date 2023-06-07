using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GreetingTxt : MonoBehaviour
{
    TMP_Text greetingsText;
    bool firstLoaded = false;

    private void Awake()
    {
        greetingsText = GetComponent<TMP_Text>();
        DataManagerSingleton.DataLoaded += UpdateText;
    }

    private void OnEnable()
    {
        if(firstLoaded)
        {
            UpdateText();
        }
        
    }

    private void OnDestroy()
    {
        DataManagerSingleton.DataLoaded -= UpdateText;
    }

    private void UpdateText()
    {
        string playerName = DataManagerSingleton.savedData.playerName;
        if (playerName != "")
        {
            greetingsText.text = "Welcome " + playerName;
        }
        else
        {
            greetingsText.text = "";
        }
        firstLoaded = true;
    }
}
