using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeath : MonoBehaviour
{
    public GameObject HitGO;
    public GameObject ExplosionGO;

    GameObject scoreUITextGO;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);

            PlayExplosion();

            scoreUITextGO.GetComponent<GameScore>().Score += 50;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        // Detect collision of the enemy ship with the player ship, or with a player's bullet
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayHit();

            TakeDamage(40);
        }

        if (col.tag == "PlayerBullet2Tag")
        {
            PlayHit();

            TakeDamage(80);
        }
    }

    void PlayHit()
    {
        GameObject explosion = (GameObject)Instantiate(HitGO);

        explosion.transform.position = transform.position;
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);

        explosion.transform.position = transform.position;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
