using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    
    private void Awake()
    {
        AudioManager.AudioValuesSet += StartPlaying;

        // Event subs
        GameManager.PlayStage += AudioFull;
        GameManager.PauseStage += AudioLowered;

        audioSource = GetComponent<AudioSource>();

    }

    
    private void OnDestroy()
    {
        AudioManager.AudioValuesSet -= StartPlaying;

        // Event subs
        GameManager.PlayStage -= AudioFull;
        GameManager.PauseStage -= AudioLowered;
    }

    

    

    private void StartPlaying()
    {
        audioSource.Play();
    }

    // Lower audio-volume in pause menu
    private void AudioLowered()
    {
        audioSource.volume = 0.35f;
    }

    // Set Audio to 100% when entering GameState Play
    private void AudioFull()
    {
        audioSource.volume = 1f;
    }
}


