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
        GameManager.AimTurn += AimActive;
        GameManager.PowerTurn += AimInactive;
        GameManager.LaunchTurn += AimDisable;
        GameManager.PauseStage += AimFreeze;
    }

    private void AimFreeze()
    {
        AimDisable();
    }

    private void AimDisable()
    {
        _spriteRendererArrowHead.color = _disabledColor;
        _spriteRendererArrowBody.color = _disabledColor;

        print("Aim Inactive!!");
    }

    private void AimActive()
    {
        // Change Color
        _spriteRendererArrowHead.color = _activeColor;
        _spriteRendererArrowBody.color = _activeColor;

        print("Aim ACtive!!");
    }

    private void AimInactive()
    {
        // Change Color
        _spriteRendererArrowHead.color = _inactiveColor;
        _spriteRendererArrowBody.color = _inactiveColor;

        print("Aim Inactive!!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
