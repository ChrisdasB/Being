using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchController : MonoBehaviour
{
    // create event
    public static event Action LaunchingDone;

    [SerializeField] private GameObject arrowHead;
    [SerializeField] private Slider slider;
    private float powerMultiplier = 10f;
    private bool launching = false;
    Rigidbody2D rb2d;

    private void Awake()
    {
        // Event Subs
        GameManager.LaunchTurn += Launch;
        rb2d = GetComponent<Rigidbody2D>();        
    }

    private void OnDestroy()
    {
        GameManager.LaunchTurn -= Launch;
    }

    // Launch player into direction of the arrow, based on the power-slider value (times a multiplier)
    private void Launch()
    {
        Vector3 launchDirection = (arrowHead.transform.position - transform.position) * (slider.value * powerMultiplier);
        rb2d.AddForce(launchDirection,ForceMode2D.Impulse);
        launching = true;
    }

    private void Update()
    {
        // If player is currently in movement, check if player is (nearly) standing still and invoke event
        if (launching) 
        {
            if (rb2d.velocity.magnitude < 0.1f)
            {
                LaunchingDone.Invoke();
                rb2d.velocity = Vector3.zero;
                launching = false;
            }
        }
    }
}
