using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Start()
    {
        if(MySceneManager.currentScene == 0)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
