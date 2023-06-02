using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerContactController : MonoBehaviour
{
    [SerializeField] private List<Color> colors;
    [SerializeField] private float colorLerpTime;
    [SerializeField] private GameObject dangerBarrier;
    [SerializeField] private ParticleSystem colissionEmission;
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private List<AudioClip> audioClipsColission;

    private int colorIndex = 0;
    private bool transitionColors = false;

    private float maxAlpha = 1;
    private float currentAlpha = 0;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Set color to default color in the beginning
        UpdateColor();
    }

    private void FixedUpdate()
    {
        // If transition Colors is true (Animation): Set (on the first itteration) the alpha to max, then slowly decrease it after, until the original alpha is reached
        if (transitionColors)
        {
            spriteRenderer.color = new Color(colors[colorIndex].r, colors[colorIndex].g, colors[colorIndex].b, currentAlpha);
            currentAlpha -= Time.deltaTime;

            if (currentAlpha <= colors[colorIndex].a)
            {
                transitionColors = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On colission with player:
        if(collision.gameObject.tag == "Player")
        {            
            // Increase index, set transtitionColors to true           
            colorIndex++;
            transitionColors = true;
            currentAlpha = maxAlpha;

            // Check if index is available in color-list
            if (colorIndex >= colors.Count)
            {
                // If there are no colors left (Player hits this for the third time), active danger-barrier and destroy this GameObject
                dangerBarrier.SetActive(true);
                Destroy(this.gameObject);
            }
            else
            {
                // If there are colors left, set particle effect to impact position, play it, play a random sound (from DataManager) and update to next color
                colissionEmission.transform.position = collision.transform.position;
                colissionEmission.Play();
                audioPlayer.PlayOneShot(audioClipsColission[UnityEngine.Random.Range(0, audioClipsColission.Count)]);
                UpdateColor();
            }            
        }
    }

    private void UpdateColor()
    {
        spriteRenderer.color = colors[colorIndex];
    }
}
