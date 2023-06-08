using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    [SerializeField] int MainMenuScene;
    [SerializeField] int tutorialScene;
    [SerializeField] int level1Scene;
    [SerializeField] int level2Scene;
    [SerializeField] int level3Scene;

    public static event Action SceneIsLoaded;
    public static event Action DestroyOldCanvas;

    bool reload = false;
    bool menu = false;
    bool wipeSave = false;

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


    private void OnDestroy()
    {
        SceneTransitionManager.SceneClosed -= LoadLevel;
        RestartLevel.LevelRestart -= SetReloadFlag;
        BackToMenu.SetMenuFlag -= SetMenuFlag;
        SceneManager.sceneLoaded -= SceneLoaded;
        EndSceneController.EndSceneFinished -= WipeSaveGame;
    }

    private void WipeSaveGame()
    {
        menu = true;
        DataManagerSingleton.savedData = new SaveData();
        SaveManager.SaveData(DataManagerSingleton.savedData);
        Application.Quit();
    }

    private void OnEnable()
    {                
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void SetReloadFlag()
    {
        print("RELOAD FLAG SET!");
        reload = true;
        menu = false;
    }

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
        print("Build Index ist: " + SceneManager.GetActiveScene().buildIndex);
        print("Currently saved level index is: " + DataManagerSingleton.savedData.unlockedLevels);

        if(menu) 
        {
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
