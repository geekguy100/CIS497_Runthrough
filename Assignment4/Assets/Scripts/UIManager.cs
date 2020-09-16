/*****************************************************************************
// File Name :         UIManager.cs
// Author :            Kyle Grenier
// Creation Date :     September 16, 2020
// Assignment:         #4
// Brief Description : Script that manages displaying score and other game elements that need to be display via UI.
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Text scoreText;
    public int scoreToWin = 10;
    private int score = 0;
    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
            scoreText.text = "Score: " + score;
            if (score >= scoreToWin)
                GameManager.instance.GameWon = true;
        }
    }

    private void Start()
    {
        scoreText.text = "Score: 0";
    }

    public void OnGameLoss()
    {
        scoreText.text = "You Lose! Press 'R' to Retry.";
    }

    public void OnGameWon()
    {
        scoreText.text = "You Win! Press 'R' to Retry.";
    }
}