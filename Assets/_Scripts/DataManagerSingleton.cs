using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagerSingleton : MonoBehaviour
{
    // Create static Instance
    public static DataManagerSingleton Instance;

    public int triesCount;
    public AudioClip lightPowerUpAudio;
    public AudioClip triesPowerUpAudio;

    private void Awake()
    {
        // If Instance is not set, Instance is this, else destroy
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }
}
