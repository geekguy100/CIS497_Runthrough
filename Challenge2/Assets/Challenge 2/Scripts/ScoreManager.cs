/*****************************************************************************
// File Name :         ScoreManager.cs
// Author :            Kyle Grenier
// Creation Date :     9/10/2020
//
// Brief Description : Manages and tallys the player's score.
*****************************************************************************/
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    private int score = 0;
    public int scoreToWin = 5;
    public Text scoreText;

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

            //Check to see if win condition has been met.
            if (score >= scoreToWin)
                GameManager.instance.OnGameWin();
        }
    }
}