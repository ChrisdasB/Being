using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PulsatingLight : MonoBehaviour
{
    private float minLightIntesity = 0;
    private float maxLightIntesity = 0.15f;
    private float currentLightIntesity = 0;
    private float pulsatingSpeed = 0.3f;
    private Light2D myLight;
    private bool lightUp = true;

    // Start is called before the first frame update

    private void Awake()
    {
        myLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If value is going up, check if it hit max, else increase by it time * multiplier, Update light-component value
        if (lightUp)
        {
            if(currentLightIntesity > maxLightIntesity)
            {
                lightUp = false;
            }
            currentLightIntesity += (Time.deltaTime * pulsatingSpeed);
            UpdateLight();
        }
        // If value is going down, check if it hit min, else decrease it by time * multiplier, Update light-component value
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
        myLight.pointLightOuterRadius = currentLightIntesity;
    }
}
