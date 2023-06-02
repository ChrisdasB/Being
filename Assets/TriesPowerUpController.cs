using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TriesPowerUpController : MonoBehaviour
{
    public static event Action IncreaseTries;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IncreaseTries.Invoke();
            Destroy(gameObject);
        }
    }
}
