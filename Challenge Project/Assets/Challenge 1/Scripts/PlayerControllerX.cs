using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private float verticalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(-Vector3.right * rotationSpeed * verticalInput * Time.deltaTime);

        //Check to see if the player is out of bounds -- the game's loss condition.
        if (transform.position.y > 80 || transform.position.y < -51)
            ChallengeScoreManager.instance.OnLose();
    }
}