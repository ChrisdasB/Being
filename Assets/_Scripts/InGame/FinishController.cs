using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    // Shoudl honestly be named more liek TargetController...
    // Handles the finishing of a Ingame-Scene

    // Create event
    public static event Action TargetHit;
    private CircleCollider2D myCollider;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {        
        myCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On colission with player, turn color to gray and invoke event
        if(collision.gameObject.tag == "Player")
        {
            myCollider.enabled = false;
            print("Target hit!");
            spriteRenderer.color = Color.gray;
            TargetHit.Invoke();
        }
    }
}
