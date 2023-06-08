using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // This Manager is a constant component in every scene.
    // It controls the volume of the music and the SFX through the actual slider in the UI, which guaranties a synch between them.

    // Create Event
    public static event Action AudioValuesSet;

    [SerializeField] AudioMixer masterAudioMixer;
    [SerializeField] Slider masterAudioSlider;
    [SerializeField] Slider musicAudioSlider;
    [SerializeField] Slider sfxAudioSlider;
    [SerializeField] Button saveAudioBtn;

    string masterParamString = "MasterVolume";
    string musicParamString = "MusicVolume";
    string sfxParamString = "SFXVolume";

    bool blendOutAudio = false;
    bool blendInAudio = false;

    // Start is called before the first frame update
    void Awake()
    {
        // Attach eventlistener to the UI slider
        masterAudioSlider.onValueChanged.AddListener(HandleMasterAudioChanged);
        musicAudioSlider.onValueChanged.AddListener(HandleMusicAudioChanged);
        sfxAudioSlider.onValueChanged.AddListener(HandleSFXAudioChanged);

        // Event subs
        saveAudioBtn.onClick.AddListener(SaveAudioSettings);
        DataManagerSingleton.DataLoaded += SetInitialAudio;
        DataManagerSingleton.CloseScene += ClosingScene;
        GameManager.EndStage += ClosingScene;
        TutorialManager.TutorialFinished += ClosingScene;
        EndSceneController.EndSceneFinished += ClosingScene;
        MySceneManager.SceneIsLoaded += OpeningScene;
    }

    private void OnDestroy()
    {
        // Unsub events
        DataManagerSingleton.DataLoaded -= SetInitialAudio;
        DataManagerSingleton.CloseScene -= ClosingScene;
        TutorialManager.TutorialFinished -= ClosingScene;
        MySceneManager.SceneIsLoaded -= OpeningScene;
        EndSceneController.EndSceneFinished -= ClosingScene;
        GameManager.EndStage -= ClosingScene;
    }



    private void SetInitialAudio()
    {
        // Set the min and max values fot the slider (These are the same value, as the build in audio mixer in unity. Thats, why they are hardcoded)
        masterAudioSlider.minValue = -80;
        masterAudioSlider.maxValue = 0;
        sfxAudioSlider.minValue = -80;
        sfxAudioSlider.maxValue = 0;
        musicAudioSlider.minValue = -80;
        musicAudioSlider.maxValue = 0;
    }

    private void Start()
    {
        // Initalize all sliders to the loaded values
        HandleMasterAudioChanged(DataManagerSingleton.savedData.totalAudioValue);
        HandleMusicAudioChanged(DataManagerSingleton.savedData.musicAudioValue);
        HandleSFXAudioChanged(DataManagerSingleton.savedData.sfxAudioValue);
        // If we are not in the tutorial scene, invoke an event
        if(MySceneManager.currentScene != 1)
        {
            AudioValuesSet.Invoke();
        }
        
    }


    // Triggered by the save button in the options menu.
    private void SaveAudioSettings()
    {
        DataManagerSingleton.Instance.SaveAudioData(masterAudioSlider.value, musicAudioSlider.value, sfxAudioSlider.value);
    }


    // This methods will be fired, everytime someone changes the values of a audio slider. (NO SAVING)
    private void HandleMasterAudioChanged(float newVolume)
    {
        // Set new volume
        masterAudioSlider.value = newVolume;
        masterAudioMixer.SetFloat(masterParamString, newVolume);   
    }
    private void HandleMusicAudioChanged(float newVolume)
    {
        musicAudioSlider.value = newVolume;
        masterAudioMixer.SetFloat(musicParamString, newVolume);        
    }
    private void HandleSFXAudioChanged(float newVolume)
    {
        sfxAudioSlider.value = newVolume;
        masterAudioMixer.SetFloat(sfxParamString, newVolume);        
    }


    // Blending in an out music on scene change
    void ClosingScene()
    {
        blendOutAudio = true;
    }
    private void OpeningScene()
    {
        blendInAudio = true;
    }

    // Values get changed 50 times a second.
    private void FixedUpdate()
    {
        if(blendOutAudio) 
        {
            if (musicAudioSlider.value <= musicAudioSlider.minValue)
            {
                blendOutAudio = false;
            }
            HandleMusicAudioChanged(musicAudioSlider.value - 1f);            
        }

        if (blendInAudio)
        {
            if (musicAudioSlider.value >= DataManagerSingleton.savedData.musicAudioValue)
            {
                blendInAudio = false;
                HandleMusicAudioChanged(DataManagerSingleton.savedData.musicAudioValue);
            }

            HandleMusicAudioChanged(musicAudioSlider.value + 1f);            
        }
    }

}
