/*****************************************************************************
// File Name :         PlayerController.cs
// Author :            Kyle Grenier
// Creation Date :     11/7/2020
// Assignment 7
// Brief Description : Player controller script; controls player via button input.
*****************************************************************************/
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 5f;

    private float forwardInput;
    private GameObject focalPoint;

    [SerializeField] private GameObject powerupIndicator = null;
    private bool hasPowerup = false;
    private float powerupStength = 15.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("Focal_Point");
    }

    private void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        //Update powerup indicator's position to the player.
        //The vector3 we add to the player's position is an offet.
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void FixedUpdate()
    {
        rb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7f);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("Player has collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);

            //Get a local reference to the enemy rigidbody.
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

            //Set a vector3 in the direction AWAY from the player.
            Vector3 awayFromPlayer = (collision.transform.position - transform.position).normalized;

            //Add an impulse force to the enemy away from the player.
            enemyRb.AddForce(awayFromPlayer * powerupStength, ForceMode.Impulse);
        }
    }
}