using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class DataManagerSingleton : MonoBehaviour
{
    // This static singleton servers as a holder for vital data, needed in every scene.
    // Most importantly, it holds the actual savedata of the player

    // Create Events
    public static event Action DataLoaded;
    public static event Action CloseScene;
    public static event Action LevelFinishedAndSaved;
    

    // Create static Instance
    public static DataManagerSingleton Instance;

    public static int triesCount;
    public AudioClip lightPowerUpAudio;
    public AudioClip triesPowerUpAudio;

    // Save Data
    public static SaveData savedData;

    public static string newPlayerName;

    private void Awake()
    {
        // Event subs
        NewPlayerNameController.NewPlayer += HandleNewPlayer;
        GameManager.WinStage += SaveProgression;
        ContinueButton.OnContinue += ContinueGame;
        TutorialManager.TutorialFinished += SaveNextLvl;
        EndSceneController.EndSceneFinished += ResetSave;
    

        // If Instance is not set, Instance is this, else destroy
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        // If we have no Save file, create one
        if(!SaveManager.CheckForSaveGame())
        {
            // Do the first save with the default values from constructor
            SaveManager.SaveData(new SaveData());
            print("Default values saved!");
        }

        // Load the data from file
        savedData = SaveManager.LoadData();
        DataLoaded.Invoke(); print("onvking event");       
    }

    // After game is finished, feed the savegame with initial data
    private void ResetSave()
    {
        savedData = new SaveData();
    }

    // After the tutorial, save the first level into savedata (The tutorial-scene works different from the other scenes)
    private void SaveNextLvl()
    {        
        savedData.unlockedLevels = 2;
        SaveManager.SaveData(savedData);
    }

    // Save the current player progression
    private void SaveProgression()
    {
        print("Saving Progression!");
        savedData.unlockedLevels = SceneManager.GetActiveScene().buildIndex + 1;
        SaveManager.SaveData(savedData);
        CloseScene.Invoke();
    }

    // If a new game is startet, get the savegame ready
    private void HandleNewPlayer()
    {
        SaveData dataToSave = new SaveData(newPlayerName);
        // Take the currently set audio settings into new player savegame
        dataToSave.totalAudioValue = savedData.totalAudioValue;
        dataToSave.musicAudioValue = savedData.musicAudioValue;
        dataToSave.sfxAudioValue = savedData.sfxAudioValue;

        SaveManager.SaveData(dataToSave);
        savedData = SaveManager.LoadData();
        DataLoaded.Invoke();
        CloseScene.Invoke();
    }

    // For the continue option in menu, if a valid savegame was found
    private void ContinueGame()
    {
        CloseScene.Invoke();
    }

    public void SaveAudioData(float masterAudio, float musicAudio, float sfxAudio)
    {
        savedData.totalAudioValue = masterAudio;
        savedData.musicAudioValue = musicAudio;
        savedData.sfxAudioValue = sfxAudio;
        
        SaveManager.SaveData(savedData);
        print("Audio has been saved!");
    }
}
