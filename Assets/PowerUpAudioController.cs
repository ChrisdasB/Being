using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PowerUpAudioController : MonoBehaviour
{
    private AudioSource audioPlayer;

    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
        // Event Subs
        LightPowerUpController.IncreaseLight += PlayLightSound;
        TriesPowerUpController.IncreaseTries += PlayTriesSound;
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
