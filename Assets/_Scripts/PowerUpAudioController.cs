using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Global AudioSource for PowerUps (exclusively)
public class PowerUpAudioController : MonoBehaviour
{
    private AudioSource audioPlayer;

    private void Awake()
    {
        // Event Subs
        LightPowerUpController.IncreaseLight += PlayLightSound;
        TriesPowerUpController.IncreaseTries += PlayTriesSound;

        audioPlayer = GetComponent<AudioSource>();        
    }

    private void PlayTriesSound()
    {
        audioPlayer.PlayOneShot(DataManagerSingleton.Instance.triesPowerUpAudio);
    }

    private void PlayLightSound()
    {
        audioPlayer.PlayOneShot(DataManagerSingleton.Instance.lightPowerUpAudio);
    }
}
