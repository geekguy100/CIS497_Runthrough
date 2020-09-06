/*****************************************************************************
// File Name :         ScoreTrigger.cs
// Author :            Kyle Grenier
// Creation Date :     September 06, 2020
// Assignment #2
//
// Brief Description : Accumulate points by passing through this invisible trigger located between barriers.
*****************************************************************************/
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private bool triggered = false;
    public int points = 1;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && !triggered)
        {
            triggered = true;
            ChallengeScoreManager.instance.AddToScore(points);
        }
    }
}