/*****************************************************************************
// File Name :         GameManager.cs
// Author :            Kyle Grenier
// Creation Date :     11/1/2020
//
// Brief Description : GameManager class to handle game state.
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    //Keeps track of the current level.
    private string currentLevelName = string.Empty;
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private bool paused;

    private bool gameOver;
    private bool gameWon;
    public bool GameOver
    {
        get { return gameOver; }
        set
        {
            gameOver = value;
            if (gameOver && gameWon)
            {
                //You win!
                previousLevelWon = true;
            }
            else if (gameOver)
            {
                //You lose
                previousLevelWon = false;
            }

            if (gameOver)
                StartCoroutine(OnGameOver());
        }
    }
    public bool GameWon
    {
        get { return gameWon; }
        set
        {
            gameWon = value;

            //If the game has been won, end the game.
            if (gameWon)
                GameOver = true;
        }
    }

    private int level = 1;
    private bool previousLevelWon = false;

    private int winningScore = 20;
    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = "Score: " + score + " / " + winningScore;
            if (score >= winningScore)
                GameWon = true;
        }
    }

    private int lives = 3;
    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            livesText.text = "Lives " + lives;

            if (lives <= 0)
                GameOver = true;
        }
    }

    private float timeBetweenSpawns = 5f;
    public float TimeBetweenSpawns
    {
        get { return timeBetweenSpawns; }
    }

    private void Start()
    {
        currentLevelName = SceneManager.GetActiveScene().name;
        if (currentLevelName != "MainMenu")
            SetupLevel();
    }

    void FindUI()
    {
        if (levelText == null)
            levelText = GameObject.Find("Level Text").GetComponent<TextMeshProUGUI>();
        if (livesText == null)
            levelText = GameObject.Find("Lives Text").GetComponent<TextMeshProUGUI>();
        if (scoreText == null)
            levelText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Perform level setup: adjust difficulty and start gameplay.
    /// </summary>
    public void SetupLevel()
    {
        FindUI();
        currentLevelName = SceneManager.GetActiveScene().name;

        if (previousLevelWon)
        {
            timeBetweenSpawns -= 0.5f;

            if (timeBetweenSpawns < 1f)
                timeBetweenSpawns = 1f;

            ++level;
        }

        Cursor.lockState = CursorLockMode.Locked;

        levelText.text = "Level " + level;
        Lives = 3;
        Score = 0;

        //Start spawning cubes.
        GameObject.Find("Cube Spawner").GetComponent<CubeSpawner>().StartSpawning();
    }

    private IEnumerator OnGameOver()
    {
        yield return new WaitForSeconds(3f);
        LoadLevel(currentLevelName);
    }

    //Methods to load and unload the scene.
    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
        if (ao == null)
        {
            Debug.LogError("[GameManager]: Unable to load level " + levelName + ".");
            return;
        }

        currentLevelName = levelName;
    }

    public void UnloadLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(currentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager]: Unable to unload level " + currentLevelName + ".");
            return;
        }
    }

    //Pausing and unpausing.
    public void Pause()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && pauseMenu != null)
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.R))
            SetupLevel();
    }
}