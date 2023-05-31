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
        GameManager.AimTurn += ActivateAim;
        GameManager.PowerTurn += DeactivateAim;
    }

    private void ActivateAim() { _aimActive = true;}

    private void DeactivateAim() { _aimActive = false;}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_aimActive)
        {
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(_arrowObject.transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            _arrowObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }
}
