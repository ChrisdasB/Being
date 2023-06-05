using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelMusicControler : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        AudioManager.AudioValuesSet += StartPlaying;

        // Event subs
        GameManager.PlayStage += AudioFull;
        GameManager.PauseStage += AudioLowered;
        MySceneManager.SceneIsLoaded += GetAudioSource;

        audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        AudioManager.AudioValuesSet -= StartPlaying;

        // Event subs
        GameManager.PlayStage -= AudioFull;
        GameManager.PauseStage -= AudioLowered;
        MySceneManager.SceneIsLoaded -= GetAudioSource;
    }

    private void GetAudioSource()
    {
        audioSource = this.AddComponent<AudioSource>();
    }

    private void OnEnable()
    {
        audioSource = this.AddComponent<AudioSource>();
    }

    private void StartPlaying()
    {
        //audioSource.Play();
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
