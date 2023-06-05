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
        myCollider = GetComponent<EdgeCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On colission with player, turn color to gray and invoke event
        if(collision.gameObject.tag == "Player")
        {
            print("Target hit!");
            spriteRenderer.color = Color.gray;
            TargetHit.Invoke();
            myCollider.enabled = false;
        }
    }

}
