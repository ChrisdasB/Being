using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    public static event Action SceneClosed;
    public static event Action SceneOpened;

    [SerializeField] GameObject transitionCanvas;
    [SerializeField] CanvasGroup transitionGroup;

    private bool closeScene = false;
    private bool openScene = false;
    // Start is called before the first frame update
    private void Awake()
    {        
        DataManagerSingleton.CloseScene += closeSceneAnim;
        MySceneManager.SceneIsLoaded += openSceneAnim;
        TutorialManager.TutorialFinished += closeSceneAnim;
        GameManager.EndStage += closeSceneAnim;
    }

    private void OnDestroy()
    {
        DataManagerSingleton.CloseScene -= closeSceneAnim;
        MySceneManager.SceneIsLoaded -= openSceneAnim;
        TutorialManager.TutorialFinished -= closeSceneAnim;
        GameManager.EndStage -= closeSceneAnim;
    }

    private void openSceneAnim()
    {
        transitionGroup = transitionCanvas.GetComponentInChildren<CanvasGroup>();
        transitionCanvas.SetActive(true);
        
        print("Attempting to open scene!");
        openScene = true;
        transitionGroup.alpha = 1;
    }

    private void closeSceneAnim()
    {
        transitionGroup = transitionCanvas.GetComponentInChildren<CanvasGroup>();
        transitionCanvas.SetActive(true);
        
        print("Attempting to close scene!");        
        closeScene = true;
        transitionGroup.alpha = 0;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(closeScene) 
        {
            transitionGroup.alpha += Time.deltaTime * 0.5f;

            if(transitionGroup.alpha >= 1)
            {                
                closeScene = false;
                SceneClosed.Invoke();
            }
        }

        if (openScene)
        {
            transitionGroup.alpha -= Time.deltaTime * 0.5f;

            if (transitionGroup.alpha <= 0)
            {
                openScene = false;
                SceneOpened.Invoke();
            }
        }
    }
}
