using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseGame : MonoBehaviour
{
    Button button;
    // Start is called before the first frame update

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(HandleCloseGame);
    }
   private void HandleCloseGame() 
    {
        Application.Quit();
        print("Quitting Game!");
    }
}
