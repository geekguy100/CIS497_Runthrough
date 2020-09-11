/*****************************************************************************
// File Name :         ScoreManager.cs
// Author :            Kyle Grenier
// Creation Date :     September 10, 2020
//
// Brief Description : Manages tallying and displaying the player's score.
*****************************************************************************/
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    public Text textbox;
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
            textbox.text = "Score: " + score;
        }
    }

    private void Start()
    {
        textbox.text = "Score: 0";
    }
}