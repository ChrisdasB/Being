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
    public static event Action LeftMouseClicked;
    public static event Action RightMouseClicked;
    public static event Action DEBUGCLICKED;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
   

    // Update is called once per frame
    void Update()
    {
        // On Mouse-Left Click invoke event
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            LeftMouseClicked.Invoke();
        }
        // On Mouse-Right Click invoke event
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RightMouseClicked.Invoke();
        }
        // On Escape Click invoke event
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            EscapeClicked.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            DEBUGCLICKED.Invoke();
        }

        // The Camera is for now controller in this script. Maybe a subject to change, if i need more functionality for the camera
        // Mousewheel up: Zoom in camera by 1, if not on minZoom
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if ((cmCamera.m_Lens.OrthographicSize + 1) > minZoomOut)
            {
                cmCamera.m_Lens.OrthographicSize = cmCamera.m_Lens.OrthographicSize - 1;
            }
        }
        // Mousewheel Down: Zoom out camera by 1, if not on maxZoom
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if((cmCamera.m_Lens.OrthographicSize + 1) < maxZoomOut)
            {
                cmCamera.m_Lens.OrthographicSize = cmCamera.m_Lens.OrthographicSize + 1;
            }            
        }
        
    }
}
