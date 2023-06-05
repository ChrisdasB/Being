using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class NewPlayerNameController : MonoBehaviour
{
    public static event Action NewPlayer;

    TMP_InputField inputField;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    public void NewPlayerName()
    {
        DataManagerSingleton.newPlayerName = inputField.text;
        NewPlayer.Invoke();
    }
}
