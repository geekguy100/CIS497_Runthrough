/*****************************************************************************
// File Name :         PlayerWinTrigger.cs
// Author :            Kyle Grenier
// Creation Date :     10/5/2020
// Assignment #5
// Brief Description : Script that controls what occurs when the player compeltes the level.
*****************************************************************************/
using UnityEngine;

public class PlayerWinTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        //If the player enters the win trigger and has reached the winning score, display win text.
        //If they don't have enough gems, let them know.
        if (col.CompareTag("Player") && ScoreManager.instance.scoreReached)
            ScoreManager.instance.OnWin();
        else if (col.CompareTag("Player"))
            ScoreManager.instance.ShowLowScoreMsg();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //If the player leaves the trigger, hide the low score msg.
        if (col.CompareTag("Player") && !ScoreManager.instance.scoreReached)
            ScoreManager.instance.HideLowScoreMsg();
    }
}