using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    // Script attached to the restart button on the pause menu

    public static event Action LevelRestart;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        LevelRestart.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
