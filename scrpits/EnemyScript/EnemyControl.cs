using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    float speed; // For the enemy speed

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f; // Set speed
    }

    // Update is called once per frame
    void Update()
    {
        // Get the enemy current position
        Vector2 position = transform.position;

        // Compute the enemy new position
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        
        // Upgrade the enemy position
        transform.position = position;

        // This is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // If the enemy went outside the screen on the bottom, then destroy the enemy
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
}