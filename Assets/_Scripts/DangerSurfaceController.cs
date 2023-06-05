using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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

    public void SetSize(float sizeY, Vector3 pos)
    {
        Vector3 newSize = new Vector3(0.15f, sizeY, 1);
        transform.localPosition = pos;
        transform.localScale = newSize;
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
