using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;


public class StarGenerator : MonoBehaviour
{
    public GameObject StarGO; // This is our StarGO prefab
    public int MaxStars; // The maximum number of stars

    // Array of colors
    Color[] starColors =
    {
        new Color (0.5f, 0.5f, 1f), // Blue
        new Color (0, 1f, 1f), // Green
        new Color (1f, 1f, 0), // Yellow
        new Color (1f, 0, 0), // Red
    };

    // Start is called before the first frame update
    void Start()
    {
        // This is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // This is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Loop to create the stars
        for(int i = 0; i < MaxStars; ++i)
        {
            GameObject star = (GameObject)Instantiate(StarGO);

            // Set the star color
            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];

            // Set the position of the star (random x and random y)
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            // Set a random speed for the star
            star.GetComponent<Star>().speed = -(1f * Random.value * 0.1f + 0.3f);

            // Make the star a child of the starGeneratorGO
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
