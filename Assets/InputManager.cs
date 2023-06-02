using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InputManager : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] Cinemachine.CinemachineVirtualCamera cmCamera;
    [SerializeField] int maxZoomOut = 13;
    [SerializeField] int minZoomOut = 2;

    public static event Action EscapeClicked;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
   

    // Update is called once per frame
    void Update()
    {
        // On Mouse-Left Click
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
        gameManager.MouseLeftClick();
            print("mouse has been clicked!");
        }
        // On Mouse-Right Click
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            gameManager.MouseRightClick();
            print("mouse right has been clicked!");
        }

        // On Escape
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            EscapeClicked.Invoke();
        }

        // Mousewheel up
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if ((cmCamera.m_Lens.OrthographicSize + 1) > minZoomOut)
            {
                cmCamera.m_Lens.OrthographicSize = cmCamera.m_Lens.OrthographicSize - 1;
            }
        }
        // Mousewheel Down
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if((cmCamera.m_Lens.OrthographicSize + 1) < maxZoomOut)
            {
                cmCamera.m_Lens.OrthographicSize = cmCamera.m_Lens.OrthographicSize + 1;
            }            
        }
        
    }
}
