using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCameraAfterLoad : MonoBehaviour
{
    [SerializeField] Canvas globalCanvas;
    // Start is called before the first frame update
    void Awake()
    {
        MySceneManager.SceneIsLoaded += GetCamera;
    }

    private void OnDestroy()
    {
        MySceneManager.SceneIsLoaded -= GetCamera;
    }

    private void GetCamera()
    {
        globalCanvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
