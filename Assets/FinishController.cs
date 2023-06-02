using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public static event Action TargetHit;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {        
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spriteRenderer.color = Color.gray;
            TargetHit.Invoke();
        }
    }

}
