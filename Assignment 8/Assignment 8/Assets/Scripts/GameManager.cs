/*****************************************************************************
// File Name :         GameManager.cs
// Author :            Kyle Grenier
// Creation Date :     11/17/2020
// Assignment 8
// Brief Description : A GameManager class to handle the game state and spawning objects.
*****************************************************************************/
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<GameObject> targets = null;
    private float spawnRate = 1f;

    //Scoring vars
    [SerializeField] private TextMeshProUGUI scoreText = null;
    private int score = 0;
    //Decided to use a property to update score & score text instead of writing a function.
    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
            scoreText.text = "SCORE: " + score;
        }
    }

    //Game over vars
    [SerializeField] private GameObject gameOverText = null;
    [SerializeField] private GameObject restartButton = null;
    private bool gameOver = false;
    public bool GameOver
    {
        get { return gameOver; }

        set
        {
            gameOver = value;
            gameOverText.SetActive(gameOver);
            restartButton.SetActive(gameOver);
        }
    }

    //Title screen
    [SerializeField] private GameObject titleScreen = null;

    /// <summary>
    /// Deactivates the title screen, adjust difficulty, and starts spawning targets.
    /// </summary>
    public void StartGame(int difficulty)
    {
        titleScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        spawnRate /= difficulty;
        GameOver = false;
        Score = 0;

        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (!gameOver)
        {
            //Wait 1 second.
            yield return new WaitForSeconds(spawnRate);

            //Pick a random index betwwen 0 and number of prefabs.
            int index = Random.Range(0, targets.Count);

            //Spawn prefab at random index.
            Instantiate(targets[index]);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}