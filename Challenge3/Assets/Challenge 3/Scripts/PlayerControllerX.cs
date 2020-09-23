/*****************************************************************************
// File Name :         PlayerControllerX.cs
// Author :            Kyle Grenier
// Creation Date :     9/21/2020
// Assignment:         Challenge 3
// Brief Description : Controls the player character.
*****************************************************************************/
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    private bool isLowEnough = true;
    [SerializeField] private float maxHeight = 14.1f;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !ScoreManager.instance.GameOver && isLowEnough)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    private void Update()
    {
        //If the player goes too high, make them unable to add a force to the balloon.
        if (transform.position.y > maxHeight)
            isLowEnough = false;
        else
            isLowEnough = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set ScoreManager.instance.GameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            ScoreManager.instance.GameOver = true;
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            ScoreManager.instance.Score += other.gameObject.GetComponent<Grabbable>().Points;
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        //If the player collides with the ground, add a force to make the player bounce.
        else if (other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up * 15f, ForceMode.VelocityChange);
        }

    }

}
