/*****************************************************************************
// File Name :         PlayerController.cs
// Author :            Kyle Grenier
// Creation Date :     September 08, 2020
//
// Brief Description : Allows for control of player character.
*****************************************************************************/
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private float xRange = 14;

    private void Update()
    {
        //Get horizontal input from right and left arrow keys or from A and D keys
        float horizontalInput = Input.GetAxis("Horizontal");

        //Transform horizontally with input
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        //Make sure the player stays in bounds
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -xRange, xRange);
        transform.position = pos;
    }
}