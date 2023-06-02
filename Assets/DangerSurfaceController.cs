using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DangerSurfaceController : MonoBehaviour
{
    public static event Action PlayerDied;
    [SerializeField] AudioSource audioPlayer;
    [SerializeField] AudioClip brokenSound;
    // Start is called before the first frame update

    private void OnEnable()
    {
        audioPlayer.PlayOneShot(brokenSound);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerDied.Invoke();
        }
    }
}
