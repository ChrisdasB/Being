using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRendererArrowBody;
    [SerializeField] private SpriteRenderer _spriteRendererArrowHead;

    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;
    [SerializeField] private Color _disabledColor; 

    private void Awake()
    {
        // Event subs
        GameManager.AimTurn += AimActive;
        GameManager.PowerTurn += AimInactive;
        GameManager.LaunchTurn += AimDisable;
        GameManager.PauseStage += AimDisable;
        GameManager.TutorialStage += AimDisable;

        AimDisable();
    }


    private void AimDisable()
    {
        // Set arrow to disabled color when game is paused or launch-event is invoked
        _spriteRendererArrowHead.color = _disabledColor;
        _spriteRendererArrowBody.color = _disabledColor;
    }

    private void AimActive()
    {
        // Set arrow to active color
        _spriteRendererArrowHead.color = _activeColor;
        _spriteRendererArrowBody.color = _activeColor;        
    }

    private void AimInactive()
    {
        // Set arrow to inactive color (After log in, so the player can still see where he aimed at while managing the power)
        _spriteRendererArrowHead.color = _inactiveColor;
        _spriteRendererArrowBody.color = _inactiveColor;
    }
    
}
