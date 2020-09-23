/*****************************************************************************
// File Name :         MoveLeftX.cs
// Author :            Kyle Grenier
// Creation Date :     9/21/2020
// Assignment:         Challenge 3
// Brief Description : Controls game objects moving left.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed;
    private float leftBound = -10;

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (!ScoreManager.instance.GameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}
