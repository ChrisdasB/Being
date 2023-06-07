using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    // Create event
    public static event Action TargetHit;
    private EdgeCollider2D myCollider;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        InputManager.DEBUGCLICKED += DEBUGSKIPLVL;
        myCollider = GetComponent<EdgeCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDestroy()
    {
        InputManager.DEBUGCLICKED -= DEBUGSKIPLVL;
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

    void DEBUGSKIPLVL()
    {
        myCollider.enabled = false;
        print("Target hit!");
        spriteRenderer.color = Color.gray;
        TargetHit.Invoke();
        myCollider.enabled = false;
    }

}
