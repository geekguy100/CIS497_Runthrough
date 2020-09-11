/*****************************************************************************
// File Name :         DetectCollisionX.cs
// Author :            Kyle Grenier
// Creation Date :     9/10/2020
//
// Brief Description : Runs appropriate code for when a dog collides with a ball.
*****************************************************************************/
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Dog"))
        {
            ScoreManager.instance.Score++;
            Destroy(gameObject);
        }
    }
}