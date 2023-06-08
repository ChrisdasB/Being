using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ContollsUI : MonoBehaviour
{
    [SerializeField] List<GameObject> listGO;
    int currentGOindex = -1;

    Vector3 growVector = new Vector3 (0.05f, 0.05f, 0.05f);

    bool WaitAndTrigger = false;
    bool blendIn = false;
    bool blendOut = false;
    float pauseSeconds;
    float timeBetweenActions = 2;
    int functionIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        WaitSecondsAndCallNextVoid(timeBetweenActions);
    }

    void WaitSecondsAndCallNextVoid(float seconds)
    {
        pauseSeconds = seconds;
        WaitAndTrigger = true;
    }

    // Update is called once per frame
    void FixedUpdate()
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

        if (blendIn)
        {
            listGO[currentGOindex].transform.localScale += growVector;
            if(listGO[currentGOindex].transform.localScale.x >= 1)
            {
                blendIn = false;
                listGO[currentGOindex].transform.localScale = Vector3.one;
                WaitSecondsAndCallNextVoid(timeBetweenActions);
            }
        }

        if (blendOut)
        {
            for(int i = 0; i < listGO.Count; i++)
            {
                listGO[i].transform.localScale -= growVector;
            }

            if (listGO[currentGOindex].transform.localScale.x <= 0)
            {
                blendOut = false;
                listGO[currentGOindex].transform.localScale = Vector3.zero;
            }
        }
    }

    private void NextFunction()
    {
        if(functionIndex == 0) { blendInText(); }
        if(functionIndex == 1) { blendInText(); }
        if(functionIndex == 2) { blendInText(); }
        if(functionIndex == 3) { blendInText(); }
        if(functionIndex == 4) { WaitSecondsAndCallNextVoid(3); }
        if(functionIndex == 5) { blendOutAll(); }
    }

    private void blendOutAll()
    {
        blendOut = true;
    }

    private void blendInText()
    {
        blendIn = true;
        currentGOindex++;
    }
}
