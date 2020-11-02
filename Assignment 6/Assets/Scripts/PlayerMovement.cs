/*****************************************************************************
// File Name :         PlayerMovement.cs
// Author :            Kyle Grenier
// Creation Date :     September 18, 2020
// Assignment 6
// Brief Description : Enables movement of the player character.
*****************************************************************************/
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;

    //Velocity is for dealing with gravity, moveDirection is a velocity for movement.
    private Vector3 velocity;

    //Our current moveDirection. If grounded, we have direct control,
    //but if we're in the air, we only have partial control.
    Vector3 moveDirection;

    //The degree to which we can control our player mid-air.
    [Range(0, 10), SerializeField] private float airControl = 5;

    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        //Get player input.
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

        //Converting input from local space to world space.
        input = transform.TransformDirection(input);

        //Multiply input by moveSpeed to get a velocity.
        input *= moveSpeed;
        
        if (controller.isGrounded)
        {
            moveDirection = input;
            //NOTE: If you wanted to make controls more slippery, consider the following:
            //moveDirection = Vector3.Lerp(moveDirection, input, movementControl * Time.deltaTime);

            //Player is grounded and wants to jump. 
            //Calculate an upwards velocity to apply to the player.
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            //Player is grounded and not jumping.
            //Set downward motion to 0.
            else
            {
                moveDirection.y = 0;
            }
        }
        //Player is not grounded.
        //Slowly bring our movement towards the user's desired input, 
        //but preserve out current y-direction (so that the arc of our jump is preserved).
        else
        {
            //Preserving the current y direction by putting it into the input.
            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
        }


        //Apply gravity to the player.
        moveDirection.y += gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }
}