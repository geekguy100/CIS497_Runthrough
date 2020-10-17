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
    private CharacterController controller;
    [SerializeField] private float speed = 12f;

    [SerializeField] private Vector3 velocity;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 2f;

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
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        velocity.y += gravity * Time.deltaTime;
        
        

        controller.Move(velocity * Time.deltaTime);
        controller.Move(move * speed * Time.deltaTime);
    }
}
