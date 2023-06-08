using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRightBackground : MonoBehaviour
{
    Vector3 leftPos = new Vector3(-10, 0, 0);
    Vector3 rightPos = new Vector3(10, 0, 0);
    float speed = 0.15f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = leftPos;
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, rightPos, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, rightPos) < 0.001f)
        {
            // Swap the position of the cylinder.
            rightPos *= -1.0f;
        }
    }
}
