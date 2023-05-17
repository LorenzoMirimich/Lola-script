using System.Collections;
using System.Collections.Generic; // For Queue
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] Planets; // An array of PlanetGO prefabs

    // Queue to hold the planets
    Queue<GameObject> availablePlanets = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Add the planets to the Queue (Enqueue them)
        availablePlanets.Enqueue(Planets[0]);
        availablePlanets.Enqueue(Planets[1]);
        availablePlanets.Enqueue(Planets[2]);

        // Call the MovePlanetDown function every 20 seconds
        InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to dequeue a planet, and set its isMoving flag to true
    // So that the planet starts scrolling down the screen
    void MovePlanetDown()
    {
        EnqueuePlanets();

        // If the Queue is empty, then return
        if (availablePlanets.Count == 0)
            return;

        // Get a planet from the queue
        GameObject aPlanet = availablePlanets.Dequeue();

        // Set the planet is Moving flag to true
        aPlanet.GetComponent<Planet>().isMoving = true;
    }

    // Function to Enqueue planets that are below the screen and are not moving
    void EnqueuePlanets()
    {
        foreach(GameObject aPlanet in Planets)
        {
            // If the planet is below the screen, and the planet is not moving
            if((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<Planet>().isMoving))
            {
                // Reset the planet position
                aPlanet.GetComponent<Planet>().ResetPosition();

                //Enqueue the planet
                availablePlanets.Enqueue(aPlanet);
            }
        }
    }
}
