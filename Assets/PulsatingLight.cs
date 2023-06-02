using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PulsatingLight : MonoBehaviour
{
    float minLightIntesity = 0;
    float maxLightIntesity = 0.15f;
    float currentLightIntesity = 0;
    float pulsatingSpeed = 0.3f;
    private Light2D light;
    bool lightUp = true;

    // Start is called before the first frame update

    private void Awake()
    {
        light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(lightUp)
        {
            if(currentLightIntesity > maxLightIntesity)
            {
                lightUp = false;
            }
            currentLightIntesity += (Time.deltaTime * pulsatingSpeed);
            UpdateLight();
        }
        else
        {
            if(currentLightIntesity < minLightIntesity) 
            {
                lightUp = true;
            }
            currentLightIntesity -= (Time.deltaTime * pulsatingSpeed);
            UpdateLight();
        }
    }

    private void UpdateLight()
    {
        light.pointLightOuterRadius = currentLightIntesity;
    }
}
