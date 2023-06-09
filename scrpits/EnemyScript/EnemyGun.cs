using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

    public GameObject EnemyBulletGO; // This is our enemy bullet prefab

    // Start is called before the first frame update
    void Start()
    {
        // Fire an enemy bullet after 1 second
        Invoke ("FireEnemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to fire an enemy bullet
    void FireEnemyBullet()
    {
        // Get a reference to the player's ship
        GameObject playerShip = GameObject.Find("PlayerGO");

        if (playerShip != null) // if the player is not dead
        {
            // Instantiate an enemy bullet
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);

            // Set the bullet's initial position
            bullet.transform.position = transform.position;

            // Compute the bullet's direction towards the player's ship
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            // Set the bullet's direction
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
