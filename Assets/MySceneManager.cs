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


    public static int currentScene;
    private void Awake()
    {
        // Event subs
        DataManagerSingleton.NewPlayerSaved += LoadTutorial;

        // Set first scene to MainMenu
        currentScene = MainMenuScene;
        DontDestroyOnLoad(gameObject);
    }

    private void LoadTutorial()
    {
        currentScene = tutorialScene;
        SceneManager.LoadScene(currentScene);
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
