using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioController : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        GameManager.PlayStage += AudioFull;
        GameManager.PauseStage += AudioHalf;
    }

    private void AudioHalf()
    {
        audioSource.volume = 0.35f;
    }

    private void AudioFull()
    {
        audioSource.volume = 1f;
    }
}


