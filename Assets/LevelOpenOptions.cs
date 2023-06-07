using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOpenOptions : MonoBehaviour
{
    GameObject OptionsMenuPanel;
    GameObject OptionsScreen;

    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        OptionsMenuPanel = GameObject.FindGameObjectWithTag("GlobalCanvas");

        button.onClick.AddListener(ToggleOptions);
    }

    private void ToggleOptions()
    {
        if(OptionsMenuPanel.activeSelf == false) 
        {
            OptionsMenuPanel.SetActiveRecursively(true);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
