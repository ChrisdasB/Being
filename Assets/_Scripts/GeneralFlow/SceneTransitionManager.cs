using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    // This script controls the fade in and fade out animations.
    // I decided to not go with the Unity build-in animator, since this is supposed to be a coding project.
    // And to be honest, i found this actually easier than the animator in some cases ...

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
        EndSceneController.EndSceneFinished += closeSceneAnim;
        GameManager.EndStage += closeSceneAnim;
    }

    private void OnDestroy()
    {
        DataManagerSingleton.CloseScene -= closeSceneAnim;
        MySceneManager.SceneIsLoaded -= openSceneAnim;
        EndSceneController.EndSceneFinished -= closeSceneAnim;
        TutorialManager.TutorialFinished -= closeSceneAnim;
        GameManager.EndStage -= closeSceneAnim;
    }

    private void openSceneAnim()
    {
        transitionCanvas.SetActive(true);
        transitionGroup = transitionCanvas.GetComponentInChildren<CanvasGroup>();        
        openScene = true;
        transitionGroup.alpha = 1;
    }

    private void closeSceneAnim()
    {
        transitionCanvas.SetActive(true);
        transitionGroup = transitionCanvas.GetComponentInChildren<CanvasGroup>();                     
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
                transitionCanvas.SetActive(false);
                if(SceneOpened != null)
                {
                    SceneOpened.Invoke();
                }
                
            }
        }
    }
}
