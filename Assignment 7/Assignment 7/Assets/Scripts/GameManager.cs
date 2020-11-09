/*****************************************************************************
// File Name :         GameManager.cs
// Author :            Kyle Grenier
// Creation Date :     11/8/2020
//
// Brief Description : Script to manage game state.
*****************************************************************************/
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private TextMeshProUGUI waveText = null;
    [SerializeField] private TextMeshProUGUI gameStatusText = null;

    private bool gameStarted = false;
    private bool gameOver = false;
    private bool gameWon = false;

    public bool GameStarted
    {
        get { return gameStarted; }
    }
    public bool GameOver
    {
        get { return gameOver; }
        set
        {
            gameOver = value;
            if (gameWon && gameOver)
            {
                //Game won
                gameStatusText.text = "Congrats! You Win!\nPress R to Restart...";
            }
            else if (gameOver)
            {
                //Game lost
                gameStatusText.text = "Uh oh! You Lost!\nPress R to Restart...";
            }
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

    [SerializeField] private int winningWave = 10;
    public int WinningWave { get { return winningWave; } }

    private void Start()
    {
        SetupGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
        {
            gameStarted = true;
            StartGame();
        }
        else if (gameOver && Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SetupGame()
    {
        waveText.text = "Wave: 0/" + winningWave;
        gameStatusText.text = "Survive " + winningWave + " Waves to Win!\nPress Spacebar to Continue...";
    }

    void StartGame()
    {
        gameStatusText.text = string.Empty;
    }

    public void UpdateWaveText(int currentWave)
    {
        waveText.text = "Wave: " + currentWave + "/" + winningWave;
    }
}