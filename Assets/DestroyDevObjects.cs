using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDevObjects : MonoBehaviour
{
    private void Awake()
    {
        MySceneManager.SceneIsLoaded += DestroyDevObj;
    }

    private void DestroyDevObj()
    {
        GameObject devObj = GameObject.FindGameObjectWithTag("DebugComp");
        Destroy(devObj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
