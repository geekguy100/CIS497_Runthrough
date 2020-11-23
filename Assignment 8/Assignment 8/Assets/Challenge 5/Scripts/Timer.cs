/*****************************************************************************
// File Name :         Timer.cs
// Author :            Kyle Grenier
// Creation Date :     11/22/2020
//
// Brief Description : Counts down from some time to 0 in whole numbers. At 0, the game ends.
*****************************************************************************/
using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    private GameManagerX gameManager;

    //Timer's current time.
    private int time;

    //Text to display time.
    private TextMeshProUGUI timerText;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManagerX>();
        timerText = GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// Sets the timer to the provided time.
    /// </summary>
    /// <param name="time">The time to set the timer to.</param>
    public void SetTime(int time)
    {
        this.time = time;
        UpdateText();
    }

    /// <summary>
    /// Returns the timer's current time.
    /// </summary>
    /// <returns>The timer's current time.</returns>
    public int GetTime()
    {
        return time;
    }

    /// <summary>
    /// Start the timer countdown.
    /// </summary>
    public void StartCountdown()
    {
        StartCoroutine(Countdown());
    }

    /// <summary>
    /// Countsdown the timer every second.
    /// </summary>
    private IEnumerator Countdown()
    {
        while(gameManager.isGameActive)
        {
            yield return new WaitForSeconds(1f);
            time -= 1;
            UpdateText();

            if (time <= 0)
                gameManager.GameOver();
        }
    }

    /// <summary>
    /// Updates the timer text with the current time.
    /// </summary>
    private void UpdateText()
    {
        timerText.text = "Time: " + time;
    }

    /// <summary>
    /// Stops the timer counting down.
    /// </summary>
    public void StopTimer()
    {
        StopCoroutine(Countdown());
    }

}