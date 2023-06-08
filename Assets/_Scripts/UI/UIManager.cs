using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text triesCount;
    [SerializeField] GameObject triesCountContainer;  
    

    private void Awake()
    {
        //Event Subs
        GameManager.UpdateTries += UpdateTries;
        GameManager.LaunchTurn += UpdateTries;
    }

    private void OnDestroy()
    {
        GameManager.UpdateTries -= UpdateTries;
        GameManager.LaunchTurn -= UpdateTries;
    }

    private void Start()
    {
        // Set triesText to initial value
        DataManagerSingleton.triesCount = 3;
        UpdateTries();
    }


    // Update TriesText by value saved in the DataManager
    void UpdateTries()
    {
        if(triesCount != null) 
        {
            triesCount.text = DataManagerSingleton.triesCount.ToString();
        }
        if(!triesCount.enabled)
        {
            triesCountContainer.SetActive(true);
        }
    }
}
