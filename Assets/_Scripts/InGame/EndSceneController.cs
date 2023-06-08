using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EndSceneController : MonoBehaviour
{
    // This Controller exclusively controls the very last scene.
    // Lets every char be added after the other, making a nice effect.

    public static event Action EndSceneFinished;

    [SerializeField] List<string> endSceneTxt;
    [SerializeField] TMP_Text endSceneText;
    [SerializeField] Light2D playerLight;

    

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip txtSound;
    private float pauseSeconds;

    public bool WaitAndTrigger = false;
    private int functionIndex = -1;
    private int indexInList = 0;
    private int indexInString;

    string currentFullString = "";

    float timeBetweenActions = 2f;
    float timeBetweenChars = 0.1f;

    // Start is called before the first frame update
    private void Start()
    {
        WaitSecondsAndCallNextVoid(2);
    }

    private void FixedUpdate()
    {
        if (WaitAndTrigger)
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

    private void NextFunction()
    {
        if(functionIndex == 0) { ShowEndSceneTxt(indexInList); }
        if(functionIndex == 1) { ShowEndSceneTxt(indexInList); }
        if(functionIndex == 2) { ShowEndSceneTxt(indexInList); }
        if (functionIndex == 3) { ShowEndSceneTxt(indexInList); }
        if (functionIndex == 4) { ShowEndSceneTxt(indexInList); }
        if (functionIndex == 5) { ShowEndSceneTxt(indexInList); }
        if (functionIndex == 6) { ShowEndSceneTxt(indexInList); }
        if (functionIndex == 7) { ShowEndSceneTxt(indexInList); }
        if (functionIndex == 8) { ShowEndSceneTxt(indexInList); }
        if (functionIndex == 9) { ShowEndSceneTxt(indexInList); }
        if (functionIndex == 10) { EndSceneFinished.Invoke();  }
    }

    private void ShowEndSceneTxt(int index)
    {
        if (indexInString >= endSceneTxt[indexInList].Length)
        {

            indexInList++;
            print(indexInList);
            indexInString = 0;
            currentFullString = "";
            // Set next void to StartAnim
            WaitSecondsAndCallNextVoid(timeBetweenActions);
        }
        else
        {
            currentFullString += endSceneTxt[indexInList][indexInString];
            indexInString++;
            UpdateEndSceneTxt(currentFullString);
            StartCoroutine(PauseThenDoNextChar(timeBetweenChars));
        }
    }

    private void UpdateEndSceneTxt(string currentFullString)
    {
        endSceneText.text = currentFullString;
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(txtSound);
        }
    }

    IEnumerator PauseThenDoNextChar(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        ShowEndSceneTxt(indexInList);
    }

    void WaitSecondsAndCallNextVoid(float seconds)
    {
        pauseSeconds = seconds;
        WaitAndTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
