using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPowerUpController : MonoBehaviour
{
    public static event Action IncreaseLight;
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IncreaseLight.Invoke();
            Destroy(gameObject);
        }
    }
}
