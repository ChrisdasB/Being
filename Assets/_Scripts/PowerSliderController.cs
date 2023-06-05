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
        // Event subs
        GameManager.PowerTurn += PowerActive;
        GameManager.AimTurn += PowerDisable;
        GameManager.LaunchTurn += PowerDisable;
        GameManager.TutorialStage += PowerDisable;
        
        slider = GetComponent<Slider>();        
    }

    private void ResetSliderPosition()
    {
        throw new NotImplementedException();
    }

    void FixedUpdate()
    {
        // If Power is active:
        if (powerActive)
        {
            // If powerValue is currently going up: Check if PowerValue hit max, if not increase it by 0.01 and Update the slider (visually)
            if (powerUp)
            {
                if (powerValue >= 1)
                {
                    powerUp = false;
                }
                powerValue += 0.01f;
                UpdateSlider();
            }
            // If powerValue is currently going down: Check if PowerValue hit min, if not decrease it by 0.01 and Update the slider (visually)
            if (!powerUp)
            {
                if (powerValue <= 0)
                {
                    powerUp = true;
                }
                powerValue -= 0.01f;
                UpdateSlider();
            }
        }
    }

    // Sets PowerActive to false, hides the slider by setting the size to 0 (Not the most elegant solution, but UI elements hit a little different in Unity ... )
    private void PowerDisable()
    {        
        powerActive = false;
        slider.transform.localScale = Vector3.zero;        
    }

    // Sets PowerActive to true, resets size of the slider to 1, Initiates power value to 0, Update the Slider (visually), changes color of slider
    private void PowerActive()
    {
        slider.transform.localScale = Vector3.one;
        powerValue = 0;
        UpdateSlider();
        background.color = activeColor;
        powerActive = true;
    }

    private void UpdateSlider()
    {
        slider.value = powerValue;
    }
}