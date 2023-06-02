using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSliderController : MonoBehaviour
{
    [SerializeField] private Slider slider; 
    [SerializeField] Image background;
    [SerializeField] Color activeColor;
    [SerializeField] Color inactiveColor;
    [SerializeField] Color disabledColor;

    private bool powerActive = false;
    private bool powerUp = true;
    private float powerValue = 0;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        GameManager.PowerTurn += PowerActive;
        GameManager.AimTurn += PowerDisable;
        GameManager.LaunchTurn += PowerDisable;
    }

    private void PowerDisable()
    {
        print("Deactivating Slider!");
        powerActive = false;
        slider.transform.localScale = Vector3.zero;
        
    }

    private void PowerActive()
    {
        slider.transform.localScale = Vector3.one;
        powerValue = 0;
        UpdateSlider();
        background.color = activeColor;
        powerActive = true;
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(powerActive) 
        {
            if(powerUp) 
            {
                if(powerValue >= 1) 
                {
                    powerUp = false;
                }
                powerValue += 0.01f;
                UpdateSlider();
            }

            if(!powerUp)
            {
                if(powerValue <= 0) 
                {
                    powerUp = true;
                }
                powerValue -= 0.01f;
                UpdateSlider();
            }
        }
    }

    private void UpdateSlider()
    {
        slider.value = powerValue;
    }


}
