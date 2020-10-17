/*
 * Kyle Grenier
 * 3D Prototype
 * 
 * 10/16/2020
 * 
 * Description: Enables player to move character using WASD.
 */


using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Controller")]
    private CharacterController controller;
    [SerializeField] private float speed = 12f;
    private Vector3 move;

    [Header("Gravity")]
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 2f;

    [Header("Jumping")]
    [SerializeField] private float jumpHeight = 3f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        gravity *= gravityMultiplier;
    }

    void Update()
    {
        //Checking if grounded for free fall.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Getting input.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Assigning input to movement vector.
        move = transform.right * x + transform.forward * z;

        //If player wants to jump, set the velocity to what it needs to be to make player jump to height.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Add velocity to gravity.
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        controller.Move(move * speed * Time.deltaTime);
    }
}
