using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalAudioController : MonoBehaviour
{
    // This script is used on the seperate music sources in scenes with music
    // Controlls when to play and reduces volumen, when in pause menu
    [SerializeField] private AudioSource audioSource;
    
    private void Awake()
    {
        // Event subs
        AudioManager.AudioValuesSet += StartPlaying;        
        GameManager.PlayStage += AudioFull;
        GameManager.PauseStage += AudioLowered;

        audioSource = GetComponent<AudioSource>();
    }

    
    private void OnDestroy()
    {
        // Unsub events
        AudioManager.AudioValuesSet -= StartPlaying;        
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


