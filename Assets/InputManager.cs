using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
        gameManager.MouseLeftClick();
            print("mouse has been clicked!");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            gameManager.MouseRightClick();
            print("mouse right has been clicked!");
        }
    }
}
