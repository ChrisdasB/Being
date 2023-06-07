using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtMouse : MonoBehaviour
{
    [SerializeField] private GameObject _arrowObject;
    public bool _aimActive = false;

    private void Awake()
    {
        // Event Subs
        GameManager.AimTurn += ActivateAim;
        GameManager.PowerTurn += DeactivateAim;
    }

    private void OnDestroy()
    {
        // Event Subs
        GameManager.AimTurn -= ActivateAim;
        GameManager.PowerTurn -= DeactivateAim;
    }

    void Update()
    {   
        // If Aim is active: Move arrow depending on the mouse position
        if (_aimActive)
        {
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(_arrowObject.transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            _arrowObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void ActivateAim() 
    { 
        _aimActive = true;
    }

    private void DeactivateAim() 
    {
        _aimActive = false;
    }
    

    
}
