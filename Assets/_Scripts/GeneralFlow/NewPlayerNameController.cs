using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class NewPlayerNameController : MonoBehaviour
{
    // Script attached to the InputField fot the name
    public static event Action NewPlayer;

    TMP_InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    public void NewPlayerName()
    {
        print("Input field function called.");
        if(inputField.text != "")
        {
            DataManagerSingleton.newPlayerName = inputField.text;
            NewPlayer.Invoke();
        }        
    }
}
