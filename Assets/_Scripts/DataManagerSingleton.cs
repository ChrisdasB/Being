using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DataManagerSingleton : MonoBehaviour
{
    // Create Load Event
    public static event Action DataLoaded;
    // Create Save Event
    public static event Action SaveData;

    // Create static Instance
    public static DataManagerSingleton Instance;

    public int triesCount;
    public AudioClip lightPowerUpAudio;
    public AudioClip triesPowerUpAudio;

    // Save Data
    public static SaveData savedData;

    public static string newPlayerName;

    private void Awake()
    {
        // Event subs
        NewPlayerNameController.NewPlayer += HandleNewPlayer;

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
        DataLoaded.Invoke();
        print(savedData.playerName);
    }

    private void HandleNewPlayer()
    {
        SaveManager.SaveData(new SaveData(newPlayerName));
        savedData = SaveManager.LoadData();
        DataLoaded.Invoke();
        print("New Player: " + savedData.playerName);
    }
}
