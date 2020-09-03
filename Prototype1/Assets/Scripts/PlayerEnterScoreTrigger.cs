using UnityEngine;

/*
* Kyle Grenier
* Assignment 2
* Introduces a scoring mechanic into the game. When the player 
* enters the trigger, score is increased.
*/

public class PlayerEnterScoreTrigger : MonoBehaviour
{
    public int points = 1;
    private bool triggered = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && !triggered)
        {
            triggered = true;
            ScoreManager.instance.AddToScore(points);
        }
    }
}