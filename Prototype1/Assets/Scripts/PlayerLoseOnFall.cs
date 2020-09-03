using UnityEngine;

/*
* Kyle Grenier
* Assignment 2
* Invokes a game over scenario if the player falls off the road.
*/

public class PlayerLoseOnFall : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -1)
        {
            ScoreManager.instance.OnGameLoss();
        }
    }
}