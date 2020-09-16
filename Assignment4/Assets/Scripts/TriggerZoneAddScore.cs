/*****************************************************************************
// File Name :         TriggerZoneAddScore.cs
// Author :            Kyle Grenier
// Creation Date :     September 16, 2020
// Assignment:         #4
// Brief Description : Increments the score if the player jumps over the obstacle.
*****************************************************************************/
using UnityEngine;

public class TriggerZoneAddScore : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && !triggered)
        {
            triggered = true;
            UIManager.instance.Score++;
        }
    }
}