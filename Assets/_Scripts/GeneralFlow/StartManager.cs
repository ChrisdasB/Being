using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class StartManager : MonoBehaviour
{
    // This script manages the first few seconds in an ingame scene. 
    // simply preparing the scene for the player with some small animations

    [SerializeField] Light2D playerLight;
    [SerializeField] GameObject triesContainer;
    [SerializeField] float playerLightMaxBrigtness;
    [SerializeField] float playerLightMultiplier;
    float currentLightValue = 0;

    bool increaseLight = false;

    private void Awake()
    {
        GameManager.StartStage += HandleStartAnim;
    }

    private void OnDestroy()
    {
        GameManager.StartStage -= HandleStartAnim;
    }

    private void HandleStartAnim()
    {
        increaseLight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(increaseLight) 
        {
            print("Increasing light!");
            currentLightValue += 0.005f;
            playerLight.pointLightOuterRadius = currentLightValue;
            print("Current light value: " + currentLightValue);

            if(playerLight.pointLightOuterRadius >= playerLightMaxBrigtness)
            {
                playerLight.pointLightOuterRadius = playerLightMaxBrigtness;
                increaseLight = false;
            }
        }
    }
}
