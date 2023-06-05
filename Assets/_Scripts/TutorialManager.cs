using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TutorialManager : MonoBehaviour
{
    // Create Event
    public static event Action TutorialFinished;

    [SerializeField] Light2D playerLight;
    [SerializeField] GameObject triesContainer;
    [SerializeField] GameObject exampleBarrier;
    [SerializeField] PlayerContactController exampleBarrierController;
    [SerializeField] GameObject exampleLightPowerUp;
    [SerializeField] GameObject exampleTriesPowerUp;
    [SerializeField] GameObject exampleTarget;
    [SerializeField] GameObject fullLevelContainer;

    [SerializeField] List<string> tutorialTxt;
    int indexInList = 0;
    int indexInString = 0;
    string currentFullString = "";
    int functionIndex = -1;

    bool WaitAndTrigger = false;


    [SerializeField] float playerLightMaxBrigtness;
    [SerializeField] float playerLightMaxBrigtness2;
    [SerializeField] float playerLightMultiplier = 2;
    float currentPlayerLightTarget;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip txtSound;

    [SerializeField] TMP_Text tutorialText;

    float currentLightValue = 0;

    bool increaseLight = false;
    bool decreaseLight = false;
    private float pauseSeconds;

    private void Start()
    {
        WaitSecondsAndCallNextVoid(2);
    }


    // Update is called once per frame
    void Update()
    {
        if (increaseLight)
        {
            currentLightValue += 0.001f;
            playerLight.pointLightOuterRadius = currentLightValue;

            if (playerLight.pointLightOuterRadius >= currentPlayerLightTarget)
            {
                playerLight.pointLightOuterRadius = currentPlayerLightTarget;
                increaseLight = false;

                // Set next void to show text again
                print("Animation done. Start next function!");                
                WaitSecondsAndCallNextVoid(2);
            }
        }
        if (decreaseLight)
        {

            currentLightValue -= 0.001f;
            playerLight.pointLightOuterRadius = currentLightValue;

            if (playerLight.pointLightOuterRadius <= currentPlayerLightTarget)
            {
                playerLight.pointLightOuterRadius = currentPlayerLightTarget;
                decreaseLight = false;

                // Set next void to show text again
                print("Animation done. Start next function!");
                Destroy(exampleBarrier);
                WaitSecondsAndCallNextVoid(2);
            }
        }

        if(WaitAndTrigger)
        {
            pauseSeconds -= Time.deltaTime;
            if (pauseSeconds <= 0) 
            {
                WaitAndTrigger = false;
                functionIndex++;
                NextFunction();
            }
        }
    }

    void NextFunction()
    {
        print("Function index is: " + functionIndex);
        if (functionIndex == 0) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 1) { IncreaseLight1(); }
        if (functionIndex == 2) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 3) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 4) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 5) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 6) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 7) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 8) { IncreaseLight2(); }
        if (functionIndex == 9) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 10) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 11) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 12) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 13) { BreakExampleLine(); }
        if (functionIndex == 14) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 15) { DecreaseLight(); }
        if (functionIndex == 16) { ActivatePowerUps(); }
        if (functionIndex == 17) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 18) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 19) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 20) { ActivateTarget(); }
        if (functionIndex == 21) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 22) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 23) { ShowTutorialTxt(indexInList); }
        if (functionIndex == 24) { ActivateLevel(); }
        if (functionIndex == 25) { IncreaseLight2(); }
        if (functionIndex == 26) { TutorialFinished.Invoke(); EmptyOutTxt(); }
    }

    private void EmptyOutTxt()
    {
        tutorialText.text = string.Empty;
    }

    void WaitSecondsAndCallNextVoid(float seconds)
    {
        pauseSeconds = seconds;
        WaitAndTrigger = true;
    }

    void ShowTutorialTxt(int index)
    {        
        if(indexInString >= tutorialTxt[indexInList].Length) 
        {
            
            indexInList++;
            indexInString = 0;
            currentFullString = "";
            // Set next void to StartAnim
            WaitSecondsAndCallNextVoid(2);
        }
        else
        {            
            currentFullString += tutorialTxt[indexInList][indexInString];
            indexInString++;
            UpdateTutorialTxt(currentFullString);            
            StartCoroutine(PauseThenDoNextChar(0.01f));
        }
    }

    

    IEnumerator PauseThenDoNextChar(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        ShowTutorialTxt(indexInList);
    }

    

    private void ActivateLevel()
    {
        fullLevelContainer.SetActive(true);
        functionIndex++;
        NextFunction();
    }

    private void ActivateTarget()
    {
        exampleTarget.SetActive(true);
        WaitSecondsAndCallNextVoid(2);
    }

    private void ActivatePowerUps()
    {
        exampleLightPowerUp.SetActive(true);
        exampleTriesPowerUp.SetActive(true);
        WaitSecondsAndCallNextVoid(2);
    }

    private void DecreaseLight()
    {
        decreaseLight = true;
        currentPlayerLightTarget = playerLightMaxBrigtness;       
    }

    private void BreakExampleLine()
    {
        exampleBarrierController.DestroyBarrier();
        WaitSecondsAndCallNextVoid(2);
    }

    private void IncreaseLight1()
    {
        print("starting anim!");
        increaseLight = true;
        currentPlayerLightTarget = playerLightMaxBrigtness;
    }

    private void IncreaseLight2()
    {
        print("starting anim!");
        currentPlayerLightTarget = playerLightMaxBrigtness2;
        increaseLight = true;
    }

    void UpdateTutorialTxt(string txt)
    {
        tutorialText.text = txt;  
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(txtSound);
        }
    }
}
