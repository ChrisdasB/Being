using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPowerUpController : MonoBehaviour
{
    // Create event
    public static event Action IncreaseLight;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // IF colission with player: Invoke event and destroy this GameObject
        if (collision.gameObject.tag == "Player")
        {
            IncreaseLight.Invoke();
            Destroy(gameObject);
        }
    }
}
