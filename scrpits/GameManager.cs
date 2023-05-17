using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Reference yo our game object
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner; // Reference to our enemy spawner
    public GameObject enemySpawner2; // Reference to our enemy2 spawner
    public GameObject enemySpawner3; // Reference to our enemy3 spawner
    public GameObject asteroidSpawner; // Reference to our asteroid spawner
    public GameObject GameOverGO; // Reference to the game over image
    public GameObject scoreUITextGO; // Reference to the score text UI game object
    public GameObject TimeCounterGO; // Reference to the time counter game object
    public GameObject GameTitleGO; // Reference to the GameTitleGO

    public GameObject Counter0;
    public GameObject Counter1;
    public GameObject Counter2;
    public GameObject Counter3;
    public GameObject Counter4;
    public GameObject Counter5;
    public GameObject Counter6;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        GMState= GameManagerState.Opening;
    }

    // Update is called once per frame
    void UpdateGameManagerState()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:

                // Hide game over
                GameOverGO.SetActive(false);

                // Display the game title
                GameTitleGO.SetActive(true);

                // Set play button visible (active)
                playButton.SetActive(true);

                // Counter initial
                Counter0.SetActive(false);

                break;
            case GameManagerState.Gameplay:

                // Reset the score
                scoreUITextGO.GetComponent<GameScore>().Score = 0;

                // Hide play button on game play state
                playButton.SetActive(false);

                // Display the game title
                GameTitleGO.SetActive(false);

                // Set the player visible (active) and init the player lives
                playerShip.GetComponent<PlayerControl>().Init();

                // Start enemy spawner
                Counter0.SetActive(true);

                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();

                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                
                if (Counter1.activeInHierarchy)
                {
                    asteroidSpawner.GetComponent<AsteroidSpawner>().ScheduleEnemySpawner();
                }

                if (Counter2.activeInHierarchy)
                {
                    enemySpawner2.GetComponent<EnemySpawner2>().ScheduleEnemySpawner();
                }

                if (Counter3.activeInHierarchy)
                {
                    enemySpawner3.GetComponent<EnemySpawner3>().ScheduleEnemySpawner();
                }
                
                // Start the time counter
                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();

                break;
            case GameManagerState.GameOver:

                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();
                enemySpawner.GetComponent<EnemySpawner>().UnScheduleEnemySpawner();
                asteroidSpawner.GetComponent<AsteroidSpawner>().UnScheduleEnemySpawner();
                enemySpawner2.GetComponent<EnemySpawner2>().UnScheduleEnemySpawner();
                enemySpawner3.GetComponent<EnemySpawner3>().UnScheduleEnemySpawner();

                // Dispay game over
                GameOverGO.SetActive(true);
                /*
                // Change game manager state to Opening state after 8 seconds
                Invoke("ChangeToOpeningState", 8f);
                */
                Invoke("Restart", 8f);
                break;

        }

    }

    public void Restart()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    // Function to set the game manager state
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    // Our Play button will call this function
    // When the user clicks the button
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    // Function to change game manager state to opening state
    public void ChangeToOpeningState()
    {
        SetGameManagerState (GameManagerState.Opening);
    }
}
