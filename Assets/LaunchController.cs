using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchController : MonoBehaviour
{
    [SerializeField] private GameObject arrowHead;
    [SerializeField] private Slider slider;
    private float powerMultiplier = 5f;
    private bool launching = false;
    GameManager gameManager;

    Rigidbody2D rb2d;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>(); 
        rb2d = GetComponent<Rigidbody2D>();
        GameManager.LaunchTurn += Launch;
    }

    private void Launch()
    {
        print("Launching!");
        Vector3 launchDirection = (arrowHead.transform.position - transform.position) * (slider.value * powerMultiplier);
        rb2d.AddForce(launchDirection,ForceMode2D.Impulse);
        launching = true;
    }

    private void Update()
    {
        if (launching) 
        {
            if (rb2d.velocity.magnitude < 0.1f)
            {
                gameManager.LaunchingDone();
                rb2d.velocity = Vector3.zero;
                launching = false;
            }
        }
    }
}
