using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TriesPowerUpController : MonoBehaviour
{
    // On collission with player, trigger event to increase player tries
    // Create Event
    public static event Action IncreaseTries;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On Player trigger: invoke event, destroy this GameObject
        if (collision.gameObject.tag == "Player")
        {
            IncreaseTries.Invoke();
            Destroy(gameObject);
        }
    }
}
