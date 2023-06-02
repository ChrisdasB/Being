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

    void IncreaseLight()
    {
        nextLightValue = playerLight.pointLightOuterRadius * 1.5f;
        increaseLight = true;
    }

    private void FixedUpdate()
    {
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
