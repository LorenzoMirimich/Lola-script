using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public GameObject GameManagerGO; // Reference to our game manager

    public GameObject PlayerBulletGO; // This is our player's bullet prefab
    public GameObject PlayerBullet2GO;

    public GameObject bulletPosition00;
    public GameObject bulletPosition01;
    public GameObject bulletPosition02;
    public GameObject bulletPosition03;
    public GameObject bulletPosition04;
    public GameObject bulletPosition05;
    public GameObject bulletPosition06;
    public GameObject bulletPosition07;
    public GameObject bulletPosition08;
    public GameObject bulletPosition09;
    public GameObject bulletPosition10;
    public GameObject bulletPosition11;



    public GameObject ExplosionGO; // This is our explosion prefab

    public GameObject Level0;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;
    public GameObject Level5;
    public GameObject Level6;



    public float fireRate = 0.5f;
    private float nextFire = 0;

    // Reference to the lives ui text
    public Text LivesUIText;

    const int MaxLives = 3; // Maximum player lives
    int lives; // Current player lives

    public float speed;

    public void Init()
    {
        lives = MaxLives;

        // Update the lives UI text
        LivesUIText.text = lives.ToString();

        // Reset the player position to the center of the screen
        transform.position = new Vector2(0, 0); 

        // Set this player game object to active
        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Fire bullets when the spacebar is pressed
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            // Play the laser sound effect
            GetComponent<AudioSource>().Play();

            nextFire = Time.time + 1 / fireRate;

            if(Level0.activeInHierarchy)
            {
                // Instantiate the first bullet
                GameObject bullet00 = (GameObject)Instantiate(PlayerBulletGO);
                bullet00.transform.position = bulletPosition00.transform.position; // Set the bullet initial position
            }

            if (Level1.activeInHierarchy)
            {
                 // Instantiate the first bullet
                 GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
                 bullet01.transform.position = bulletPosition01.transform.position; // Set the bullet initial position

                 // Instantiate the second bullet
                 GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
                 bullet02.transform.position = bulletPosition02.transform.position; // Set the bullet initial position

            }

            if (Level2.activeInHierarchy)
            {
                // Instantiate the first bullet
                GameObject bullet03 = (GameObject)Instantiate(PlayerBulletGO);
                bullet03.transform.position = bulletPosition03.transform.position; // Set the bullet initial position

                // Instantiate the second bullet
                GameObject bullet04 = (GameObject)Instantiate(PlayerBulletGO);
                bullet04.transform.position = bulletPosition04.transform.position; // Set the bullet initial position

            }

            if (Level3.activeInHierarchy)
            {
                // Instantiate the first bullet
                GameObject bullet05 = (GameObject)Instantiate(PlayerBulletGO);
                bullet05.transform.position = bulletPosition05.transform.position; // Set the bullet initial position

                // Instantiate the second bullet
                GameObject bullet06 = (GameObject)Instantiate(PlayerBulletGO);
                bullet06.transform.position = bulletPosition06.transform.position; // Set the bullet initial position

            }

            if (Level4.activeInHierarchy)
            {
                // Instantiate the first bullet
                GameObject bullet07 = (GameObject)Instantiate(PlayerBullet2GO);
                bullet07.transform.position = bulletPosition07.transform.position; // Set the bullet initial position


            }

            if (Level5.activeInHierarchy)
            {
                // Instantiate the first bullet
                GameObject bullet08 = (GameObject)Instantiate(PlayerBullet2GO);
                bullet08.transform.position = bulletPosition08.transform.position; // Set the bullet initial position

                // Instantiate the second bullet
                GameObject bullet09 = (GameObject)Instantiate(PlayerBullet2GO);
                bullet09.transform.position = bulletPosition09.transform.position; // Set the bullet initial position
            }

            if (Level6.activeInHierarchy)
            {
                // Instantiate the first bullet
                GameObject bullet10 = (GameObject)Instantiate(PlayerBullet2GO);
                bullet10.transform.position = bulletPosition10.transform.position; // Set the bullet initial position

                // Instantiate the second bullet
                GameObject bullet11 = (GameObject)Instantiate(PlayerBullet2GO);
                bullet11.transform.position = bulletPosition11.transform.position; // Set the bullet initial position
            }

        }

        float x = Input.GetAxisRaw("Horizontal"); // The value will be -1, 0, or 1 (for left, no input, and right)
        float y = Input.GetAxisRaw("Vertical"); // The value will be -1, 0, or 1 (for down, no input, and up)

        // Now based on the input we compute a direction vector, and we normalize it to get a unit vector
        Vector2 direction = new Vector2 (x, y).normalized;

        // Now we call the function that computes and sets the player's position
        Move(direction);
    }

    void Move(Vector2 direction)
    {
        // Find the screen limits to the player's movement (left, right, top, and bottom edges of the screen)
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0)); // This is the bottom-left point (corner) of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1)); // This is the top-right point (corner) of the screen

        max.x = max.x - 0.225f; // Subtract the player sprite half width
        min.x = min.x + 0.225f; // Add the player sprite half width

        max.y = max.y - 0.285f; // Subtract the player sprite half height
        min.y = min.y + 0.285f; // Add the player sprite half height

        // Get the player's current position
        Vector2 pos = transform.position;

        // Calculate the new position
        pos += direction * speed * Time.deltaTime;

        // Make sure the new position is not outside the screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // Update the player's position
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Detect collision of the player ship with an enemy ship, or with an enemy bullet
        if((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();

            lives--; // Subtract one live
            LivesUIText.text = lives.ToString(); // Update lives UI text

            if(lives == 0) // If our player is dead
            {
                // Change game manager state to game over state
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

                // Hide the player's ship
                gameObject.SetActive(false);
            }
        }
    }

    // Function to instantiate an explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        // Set the position of the explosion
        explosion.transform.position = transform.position;
    }
}
