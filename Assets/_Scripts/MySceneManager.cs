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


    public static int currentScene;
    private void Awake()
    {
        // Event subs
        SceneTransitionManager.SceneClosed += LoadLevel;
        DataManagerSingleton.LevelFinishedAndSaved += LoadLevel;

        // Set first scene to MainMenu
        currentScene = MainMenuScene;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {        
          SceneManager.sceneLoaded += SceneLoaded;
    }

    private void SceneLoaded(Scene sceneObj, LoadSceneMode arg1)
    {
        if(sceneObj.buildIndex != 0)
        {
            SceneIsLoaded.Invoke();
        }
    }

    private void LoadLevel()
    {
        // Load Tutorial
        if(DataManagerSingleton.savedData.unlockedLevels == 0)
        {
            currentScene = tutorialScene;
            SceneManager.LoadScene(currentScene);
        }
        // Load Tutorial
        if (DataManagerSingleton.savedData.unlockedLevels == 1)
        {
            currentScene = level1Scene;
            SceneManager.LoadScene(level1Scene);
        }
        if (DataManagerSingleton.savedData.unlockedLevels == 2)
        {
            currentScene = level2Scene;
            SceneManager.LoadScene(level2Scene);
        }
        if (DataManagerSingleton.savedData.unlockedLevels == 3)
        {
            currentScene = level3Scene;
            SceneManager.LoadScene(level3Scene);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
