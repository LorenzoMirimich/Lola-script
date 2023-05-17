using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public GameObject Level0;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;
    public GameObject Level5;
    public GameObject Level6;

    public GameObject asteroidSpawner;
    public GameObject enemySpawner;
    public GameObject enemySpawner2;
    public GameObject enemySpawner3;

    // Reference for boolean spawner
    public GameObject Counter0;
    public GameObject Counter1;
    public GameObject Counter2;
    public GameObject Counter3;
    public GameObject Counter4;
    public GameObject Counter5;
    public GameObject Counter6;

    Text scoreTextUI;

    int score;

    // Values x for (x<score && x>score)
    public float down1;
    public float up1;
    public float down2;
    public float up2;
    public float down3;
    public float up3;
    public float down4;
    public float up4;
    public float down5;
    public float up5;
    public float down6;
    public float up6;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the Text UI component of this gameObject
        scoreTextUI = GetComponent<Text>();
    }

    // Update is called once per frame
    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format ("{0:0000000}", score);
        scoreTextUI.text = scoreStr;
    }

    void Update()
    {
        if (Score <= 0)
        {
            Level0.SetActive(true);
            Level1.SetActive(false);
            Level2.SetActive(false);
            Level3.SetActive(false);
            Level4.SetActive(false);
            Level5.SetActive(false);
            Level6.SetActive(false);

            asteroidSpawner.SetActive(false);
            enemySpawner2.SetActive(false);
            enemySpawner2.SetActive(false);
            enemySpawner3.SetActive(false);

            Counter0.SetActive(false);
            Counter1.SetActive(false);
            Counter2.SetActive(false);
            Counter3.SetActive(false);
            Counter4.SetActive(false);
            Counter5.SetActive(false);
            Counter6.SetActive(false);

        }

        // Level 1
        if (Score <= up1 && Score >= down1)
        {
            // Status Object in Hierarchy
            Level1.SetActive(true);
            Counter0.SetActive(false);
            Counter1.SetActive(true);
            asteroidSpawner.SetActive(true);
        }

        // Level 2
        if (Score <= up2 && Score >= down2)
        {
            // Status Object in Hierarchy
            Level2.SetActive(true);
            Counter1.SetActive(false);
            Counter2.SetActive(true);
            enemySpawner2.SetActive(true);
        }

        // Level 3
        if (Score <= up3 && Score >= down3)
        {
            // Status Object in Hierarchy
            Level3.SetActive(true);
            Counter2.SetActive(false);
            Counter3.SetActive(true);
            enemySpawner3.SetActive(true);
        }

        // Level 4
        if (Score <= up4 && Score >= down4)
        {
            // Status Object in Hierarchy
            Level1.SetActive(false);
            Counter3.SetActive(false);
            Counter4.SetActive(true);

        }

        // Level 5
        if (Score <= up5 && Score >= down5)
        {
            // Status Object in Hierarchy
            Level4.SetActive(true);
            Counter4.SetActive(false);
            Counter5.SetActive(true);

        }

        // Level 6
        if (Score <= up6 && Score >= down6)
        {
            // Status Object in Hierarchy
            Level5.SetActive(true);
            Counter5.SetActive(false);
            Counter6.SetActive(true);

        }
    }
}
