using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    // Responsible for the loading of the correct scene in every situation

    public static event Action SceneIsLoaded;
    public static event Action DestroyOldCanvas;

    bool reload = false;
    bool menu = false;
    bool wipeSave = false;

    // Lets other classes easily check, which scene is the current scene
    public static int currentScene;
    private void Awake()
    {
        // Event subs
        SceneTransitionManager.SceneClosed += LoadLevel;
        RestartLevel.LevelRestart += SetReloadFlag;
        BackToMenu.SetMenuFlag += SetMenuFlag;
        SceneManager.sceneLoaded += SceneLoaded;
        EndSceneController.EndSceneFinished += WipeSaveGame;

        // Set first scene to MainMenu
        currentScene = SceneManager.GetActiveScene().buildIndex;
        print("Current Scene index is:" + SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }


    private void OnDestroy()
    {
        SceneTransitionManager.SceneClosed -= LoadLevel;
        RestartLevel.LevelRestart -= SetReloadFlag;
        BackToMenu.SetMenuFlag -= SetMenuFlag;
        SceneManager.sceneLoaded -= SceneLoaded;
        EndSceneController.EndSceneFinished -= WipeSaveGame;
    }

    // Wipe savegame after game is finished, Quit the application
    private void WipeSaveGame()
    {
        menu = true;
        DataManagerSingleton.savedData = new SaveData();
        SaveManager.SaveData(DataManagerSingleton.savedData);
        Application.Quit();
    }

    // Set flag for reloading the level
    private void SetReloadFlag()
    {
        print("RELOAD FLAG SET!");
        reload = true;
        menu = false;
    }

    // Set flag for loading the menu
    private void SetMenuFlag()
    {
        print("Menu Flag Set!");
        menu = true;
        reload = false;
    }

    private void SceneLoaded(Scene sceneObj, LoadSceneMode arg1)
    {
        if(sceneObj.buildIndex != 0)
        {
            SceneIsLoaded.Invoke();
            if (wipeSave)
            {
                SaveManager.SaveData(new SaveData());
            }
        }
        
    }

    private void LoadLevel()
    {
        if(menu) 
        {
            // The good reader will notice, that i dont load the actual menu (SceneIndex 0), but instead a placeholder menu.
            // This is due to the fact, that i take the whole Menu from the first scene through the whole game.
            // This menu is instatiated in the first menu. If i would load this again, i would have 2 menus causing all sorts of problems
            print("Loading the menu!");
            menu = false;            
            SceneManager.LoadScene(9);
        }        
        else if(reload) 
        {
            print("Reloading the level!");
            reload = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);            
        }
        // Load Tutorial
        else
        {
            print("Loading Scene: " + (DataManagerSingleton.savedData.unlockedLevels));
            SceneManager.LoadScene(DataManagerSingleton.savedData.unlockedLevels);
        }
            
        
        


    }

    
}
