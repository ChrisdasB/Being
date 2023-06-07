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

    bool reload = false;
    public static int currentScene;
    private void Awake()
    {
        // Event subs
        SceneTransitionManager.SceneClosed += LoadLevel;
        GameManager.EndStage += SetReloadFlag;

        // Set first scene to MainMenu
        currentScene = SceneManager.GetActiveScene().buildIndex;
        print("Current Scene index is:" + SceneManager.GetActiveScene().buildIndex);
    }

   

    private void OnDestroy()
    {
        SceneTransitionManager.SceneClosed -= LoadLevel;
    }

    private void OnEnable()
    {        
          SceneManager.sceneLoaded += SceneLoaded;
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void SetReloadFlag()
    {
        reload = true;
    }

    private void SceneLoaded(Scene sceneObj, LoadSceneMode arg1)
    {
        if(sceneObj.buildIndex != 0)
        {
            SceneIsLoaded.Invoke();
        }
        print("SceneLoaded");
    }

    private void LoadLevel()
    {        
        print("Loading Level!");
        print("Unlocked Levels: " + DataManagerSingleton.savedData.unlockedLevels);
        if(reload) 
        { DataManagerSingleton.savedData.unlockedLevels = (SceneManager.GetActiveScene().buildIndex); reload = false; }
        print("Reloading with inden from saved data: " + DataManagerSingleton.savedData.unlockedLevels);
        // Load Tutorial
        if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(DataManagerSingleton.savedData.unlockedLevels + 1);
        }
        else
        {

            SceneManager.LoadScene(DataManagerSingleton.savedData.unlockedLevels);
        }


    }

    
}
