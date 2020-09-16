/*****************************************************************************
// File Name :         MoveLeftScript.cs
// Author :            Kyle Grenier
// Creation Date :     September 15, 2020
// Assignment:         #4
// Brief Description : Makes an obstacle move to the left at a set speed.
*****************************************************************************/
using UnityEngine;

public class MoveLeftScript : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -15f;


    private void Update()
    {
        if (!GameManager.instance.GameOver)
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        //Destroy obstacles that are out of bounds off screen to the left.
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}