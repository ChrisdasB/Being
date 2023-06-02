using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DangerSurfaceController : MonoBehaviour
{
    // Create event
    public static event Action PlayerDied;

    [SerializeField] AudioSource audioPlayer;
    [SerializeField] AudioClip brokenSound;    

    private void OnEnable()
    {
        // Play breaking sound, after GameObject was enabled
        audioPlayer.PlayOneShot(brokenSound);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On colission with player, invoke event
        if(collision.gameObject.tag == "Player")
        {
            PlayerDied.Invoke();
        }
    }
}
