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
    private Vector2 outOfBounce = new Vector2(0, 500);

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
        slider.transform.localPosition = outOfBounce;
        print("Deactivating Slider!");
        powerActive = false;
    }

    private void PowerActive()
    {
        slider.transform.localPosition = Vector2.zero;
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
