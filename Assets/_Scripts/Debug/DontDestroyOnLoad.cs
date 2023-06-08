using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Every Unity GameObject that has this attached, will not get destroyed on a scene change.
    private void Start()
    {
        if(MySceneManager.currentScene == 0)
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
