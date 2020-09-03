using UnityEngine;

/*
* Kyle Grenier
* Assignment 2
* Allows control of player game object.
*/

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 10f;

    private void Update()
    {
        //Getting user input.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Translating to player.
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        //Rotating the player with the horizontal input.
        transform.Rotate(Vector3.up, turnSpeed* Time.deltaTime * horizontalInput);
    }
}
