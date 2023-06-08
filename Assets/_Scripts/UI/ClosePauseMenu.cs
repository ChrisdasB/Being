using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePauseMenu : MonoBehaviour
{
    public static event Action ClosePause;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CloseMenu);
    }

    private void CloseMenu()
    {
        ClosePause.Invoke();
    }
    
}
