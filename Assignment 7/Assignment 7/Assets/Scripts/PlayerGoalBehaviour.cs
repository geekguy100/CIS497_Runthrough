/*****************************************************************************
// File Name :         PlayerGoalBehaviour.cs
// Author :            Kyle Grenier
// Creation Date :     11/8/2020
//
// Brief Description : Behaviour for enemies entering the player goal.
*****************************************************************************/
using UnityEngine;

public class PlayerGoalBehaviour : MonoBehaviour
{
    private int enemiesEnteredThisWave = 0;
    private int enemiesInWave = 0;

    public int EnemiesEnteredThisWave
    {
        get { return enemiesEnteredThisWave; }
        set
        {
            enemiesEnteredThisWave = value;

            //Lose the game if all of the enemies in the current wave enter the goal.
            if (enemiesEnteredThisWave >= enemiesInWave)
                GameManager.Instance.GameOver = true;
        }
    }

    public void OnWaveStart()
    {
        enemiesInWave = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}