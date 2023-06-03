using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    [SerializeField] Scene MainMenuScene;
    [SerializeField] Scene tutorialScene;
    [SerializeField] Scene level1Scene;
    [SerializeField] Scene level2Scene;
    [SerializeField] Scene level3Scene;

    public static Scene currentScene;
    private void Awake()
    {
        // Set first scene to MainMenu
        currentScene = MainMenuScene;
        DontDestroyOnLoad(gameObject);
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
