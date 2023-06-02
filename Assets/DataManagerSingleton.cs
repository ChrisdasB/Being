using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagerSingleton : MonoBehaviour
{
    public static DataManagerSingleton Instance;

    public int triesCount;
    public AudioClip lightPowerUpAudio;
    public AudioClip triesPowerUpAudio;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
}
