using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PerkController : MonoBehaviour
{
    [SerializeField] private Light2D playerLight;
    float currentLightValue = 2.5f;
    float nextLightValue = 0;
    bool increaseLight = false;

    private void Awake()
    {
        // Event Subs
        LightPowerUpController.IncreaseLight += IncreaseLight;
    }

    private void OnDestroy()
    {
        LightPowerUpController.IncreaseLight -= IncreaseLight;
    }

    // If player hit a LightPowerUp: Calculate next value and set increaseLight to true
    void IncreaseLight()
    {
        nextLightValue = playerLight.pointLightOuterRadius * 1.5f;
        increaseLight = true;
    }

    private void FixedUpdate()
    {
        // If increaseLight is true: slowly increase the lighting radius, and check if the target-value has been reached
        if (increaseLight) 
        {
            currentLightValue += Time.deltaTime;
            playerLight.pointLightOuterRadius = currentLightValue;
            if(currentLightValue >= nextLightValue) 
            {
                increaseLight = false;
                currentLightValue = nextLightValue;
            }
        }
    }

}
