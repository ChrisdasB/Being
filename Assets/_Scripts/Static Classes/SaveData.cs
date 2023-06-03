using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string playerName;
    public int unlockedLevels;
    public float totalAudioValue;
    public float musicAudioValue;
    public float sfxAudioValue;

    // For first load without a savegame
    public SaveData()
    {
        playerName = "";
        unlockedLevels = 0;
        totalAudioValue = 1;
        musicAudioValue = 1;
        sfxAudioValue = 1;
    }

    // For starting a new Game
    public SaveData(string newPlayerName)
    {
        playerName = newPlayerName;
        unlockedLevels = 0;
        totalAudioValue = 1;
        musicAudioValue = 1;
        sfxAudioValue = 1;
    }
}
