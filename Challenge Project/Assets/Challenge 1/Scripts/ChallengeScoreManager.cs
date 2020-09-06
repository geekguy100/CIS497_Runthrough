/*****************************************************************************
// File Name :         ChallengeScoreManager.cs
// Author :            Kyle Grenier
// Creation Date :     September 06, 2020
// Assignment #2
//
// Brief Description : A script to manage accumulating points in the Challenge portion of Assignment 2.
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChallengeScoreManager : Singleton<ChallengeScoreManager>
{
    private int score = 0;
    public int maxScore = 5;

    public Text gameStatusText;
    public Text scoreText;

    private bool gameOver = false;

    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddToScore(int s)
    {
        //If the player has already lost, don't accumulate score.
        if (gameOver)
            return;

        //Add 's' to score. If the game's max score has been reached, run OnWin() function.
        score += s;
        scoreText.text = "Score: " + score;
        if (score >= maxScore)
        {
            OnWin();
        }
    }

    private void OnWin()
    {
        gameOver = true;
        gameStatusText.text = "You Win!\nPress R to Restart!";
    }

    public void OnLose()
    {
        gameOver = true;
        gameStatusText.text = "You Lose!\nPress R to Try Again!";
    }
}