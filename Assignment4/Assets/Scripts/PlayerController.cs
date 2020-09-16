/*****************************************************************************
// File Name :         PlayerController.cs
// Author :            Kyle Grenier
// Creation Date :     September 15, 2020
// Assignment:         #4
// Brief Description : Script that enables player movement, jumping, etc.
*****************************************************************************/
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier = 5f;

    private bool isOnGround = true;

    private void Awake()
    {
        //Set reference to rigidbody variable.
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //Make sure the rigidbody is not using gravity because we are controlling it manually in here.
        if (rb.useGravity)
            rb.useGravity = false;
    }

    private void FixedUpdate()
    {
        //Applying gravity to JUST this rigidbody. This way we can use our gravityModifier.
        rb.AddForce(Physics.gravity * gravityModifier * rb.mass);
    }

    private void Update()
    {
        //Press Spacebar to jump
        if (Input.GetButtonDown("Jump") && isOnGround && !GameManager.instance.GameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (col.gameObject.CompareTag("Obstacle") && !GameManager.instance.GameOver)
        {
            Debug.Log("Game Over!");
            GameManager.instance.GameOver = true;
        }
    }
}