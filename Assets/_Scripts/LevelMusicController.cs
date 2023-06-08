using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicController : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource musicSource;

    bool fadeIn = false;
    float volumeTarget;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    private void StartPlayingMusic()
    {
        fadeIn = true;
        musicSource.volume = 0;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeIn)
        {
            musicSource.volume += Time.deltaTime;

            if(musicSource.volume >= 1) 
            {
                fadeIn = false;
            }
        }
    }
}
