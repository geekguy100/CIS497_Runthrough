/*****************************************************************************
// File Name :         ScoreManager.cs
// Author :            Kyle Grenier
// Creation Date :     9/21/2020
//
// Brief Description : Script that manages accumulating, managing, and displaying score.
*****************************************************************************/
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : Singleton<ScoreManager>
{
    //UI Elements
    [SerializeField] private Text scoreText;
    [SerializeField] private Text gameStatusText;

    [SerializeField] private GameObject statusPanel;

    [SerializeField] private int maxScore = 30;

    private bool gameOver = false;
    private bool gameWon = false;

    private int score;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = "Score: " + score;

            if (score >= maxScore)
                GameWon = true;
        }
    }

    public bool GameOver
    {
        get { return gameOver; }
        set
        {
            gameOver = value;

            if (!gameWon && gameOver)
            {
                gameStatusText.text = "Game Over!\nPress R to Restart.";
                statusPanel.SetActive(true);
            }
            else if (gameWon)
            {
                gameStatusText.text = "Winner!\nPress R to Restart.";
                statusPanel.SetActive(true);
            }
            else
            {
                gameWon = false;
                statusPanel.SetActive(false);
            }
        }
    }

    public bool GameWon
    {
        set
        {
            gameWon = value;

            if (gameWon)
                GameOver = true;
        }
    }

    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}