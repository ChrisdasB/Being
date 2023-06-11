using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGameUIController : MonoBehaviour
{
    // Responsible for the intro sequence after the game start.
    // Simply shows some timed text

    CanvasGroup canvasGroup;
    [SerializeField] List<TMP_Text> introTextList;
    [SerializeField] GameObject blurrPanel;
    TMP_Text currentText;

    private bool showCurrentText;
    private float pauseSeconds;
    private int functionIndex = -1;
    int textIndex = 0;

    private bool hideCurrentUI = false;
    private bool WaitAndTrigger = false;
    private bool unblurrScreen = false;

    private float textUnvealSpeed = 0.5f;


    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Start()
    {
        WaitSecondsAndCallNextVoid(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (WaitAndTrigger)
        {
            pauseSeconds -= Time.deltaTime;
            if (pauseSeconds <= 0)
            {
                WaitAndTrigger = false;
                NextFunction();
            }
        }

        if(showCurrentText) 
        {
            currentText.alpha += Time.deltaTime * textUnvealSpeed;
            
            if(currentText.alpha >= 1)
            {
                showCurrentText = false;
                currentText.alpha = 1;
                textIndex++;
                WaitSecondsAndCallNextVoid(0.2f);
            }
        }

        if(unblurrScreen)
        {
            canvasGroup.alpha -= Time.deltaTime * textUnvealSpeed;

            if(canvasGroup.alpha <= 0)
            {
                unblurrScreen = false;
                gameObject.SetActive(false);
            }
        }

        if (hideCurrentUI)
        {
            int zeroCounter = 0;
            for(int i = 0; i < introTextList.Count; i++) 
            {
                if(introTextList[i].alpha > 0)
                {
                    introTextList[i].alpha -= Time.deltaTime;
                }
                else
                {
                    zeroCounter++;
                }
            }

            if (zeroCounter == 4)
            {
                hideCurrentUI = false;

                WaitSecondsAndCallNextVoid(0.2f);
            }
        }
    }

    private void NextFunction()
    {
        if(functionIndex == 0) { StartShowUI(); }
        if(functionIndex == 1) { WaitSecondsAndCallNextVoid(0.5f); }
        if(functionIndex == 2) { StartShowUI(); }
        if(functionIndex == 3) { WaitSecondsAndCallNextVoid(2); }
        if(functionIndex == 4) { StartHideUI(); }
        if(functionIndex == 5) { WaitSecondsAndCallNextVoid(4); }
        if(functionIndex == 6) { StartShowUI(); }
        if(functionIndex == 7) { WaitSecondsAndCallNextVoid(0.5f); }
        if(functionIndex == 8) { StartShowUI(); }
        if(functionIndex == 9) { WaitSecondsAndCallNextVoid(2); }
        if(functionIndex == 10) { StartHideUI(); }
        if(functionIndex == 11) { UnblurrScreen(); }
    }

    private void StartHideUI()
    {
        hideCurrentUI = true;
    }

    private void StartShowUI()
    {
        currentText = introTextList[textIndex];
        showCurrentText = true;
    }

    void WaitSecondsAndCallNextVoid(float seconds)
    {
        pauseSeconds = seconds;
        functionIndex++;
        WaitAndTrigger = true;
    }

    void UnblurrScreen()
    {
        unblurrScreen = true;
    }

}
