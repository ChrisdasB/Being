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
                dangerBarrier.SetActive(true);
                Destroy(this.gameObject);
            }
            else
            {
                colissionEmission.transform.position = collision.transform.position;
                colissionEmission.Play();
                audioPlayer.PlayOneShot(audioClipsColission[UnityEngine.Random.Range(0, audioClipsColission.Count)]);
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
