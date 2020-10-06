/*****************************************************************************
// File Name :         ScoreManager.cs
// Author :            Kyle Grenier
// Creation Date :     10/5/2020
// Assignment #5
// Brief Description : Script to manage accumulating and displaying the score.
*****************************************************************************/
using UnityEngine;
using TMPro;

public class ScoreManager : Singleton<ScoreManager>
{
    public bool scoreReached
    {
        get;
        private set;
    }

    private int score;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = "Score: " + score;

            if (score >= maxScore)
                scoreReached = true;
        }
    }

    private int maxScore = 10;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject lowScoreText;

    private void Start()
    {
        maxScore = GameObject.FindGameObjectWithTag("Gem Parent").transform.childCount;
    }

    public void OnWin()
    {
        winText.SetActive(true);
    }

    public void ShowLowScoreMsg()
    {
        //Don't run if the text is already displaying.
        if (lowScoreText.activeInHierarchy)
            return;
            
        lowScoreText.SetActive(true);
    }

    public void HideLowScoreMsg()
    {
        //Don't run if the text is already hidden.
        if (!lowScoreText.activeInHierarchy)
            return;

        lowScoreText.SetActive(false);
    }

}