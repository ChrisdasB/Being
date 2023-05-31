using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContactController : MonoBehaviour
{
    [SerializeField] private List<Color> colors;
    [SerializeField] private float colorLerpTime;
    private int colorIndex = 0;
    private bool transitionColors = false;

    private float maxAlpha = 1;
    private float currentAlpha = 0;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            print("Player collision!");            
            colorIndex++;
            transitionColors = true;
            currentAlpha = maxAlpha;
            if (colorIndex >= colors.Count)
            {
                Destroy(this.gameObject);
            }
            else
            {
                UpdateColor();
            }
            
        }
    }

    private void FixedUpdate()
    {
        if(transitionColors)
        {
            spriteRenderer.color = new Color(colors[colorIndex].r, colors[colorIndex].g, colors[colorIndex].b, currentAlpha);
            currentAlpha -= Time.deltaTime;
            print(currentAlpha);
            print(colors[colorIndex].a);

            if(currentAlpha <= colors[colorIndex].a)
            {
                transitionColors = false;
            }
        }
        
    }

    private void UpdateColor()
    {
        spriteRenderer.color = colors[colorIndex];
    }
}
