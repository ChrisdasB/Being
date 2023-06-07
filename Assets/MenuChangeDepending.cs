using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuChangeDepending : MonoBehaviour
{
    Button button;

    [SerializeField] GameObject screenOpenInMainMenu;
    [SerializeField] GameObject screenOpenInGame;
    [SerializeField] GameObject screenToClose;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeMenuDepending);
    }

    private void ChangeMenuDepending()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0) 
        {
            screenOpenInMainMenu.SetActive(true);
            screenToClose.SetActive(false);
        }
        else
        {
            screenOpenInGame.SetActive(true);
            screenToClose.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
