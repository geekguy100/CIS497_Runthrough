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
    private Animator anim;
    public float jumpForce;
    public ForceMode jumpForceMode;
    public float gravityModifier = 5f;

    private bool isOnGround = true;

    //Particles
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;

    //SFX
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    private AudioSource audioSource;

    private void Awake()
    {
        //Set reference to rigidbody variable.
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        //Make sure the rigidbody is not using gravity because we are controlling it manually in here.
        if (rb.useGravity)
            rb.useGravity = false;

        anim.SetFloat("Speed_f", 1.0f);
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
            anim.SetTrigger("Jump_trig");
            isOnGround = false;
            audioSource.PlayOneShot(jumpSound);
            dirtParticle.Stop();
        }
        else if (GameManager.instance.GameOver && anim.GetFloat("Speed_f") != 0f)
        {
            anim.SetFloat("Speed_f", 0f);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            if (!dirtParticle.isPlaying)
                dirtParticle.Play();
        }
        else if (col.gameObject.CompareTag("Obstacle") && !GameManager.instance.GameOver)
        {
            explosionParticle.Play();
            dirtParticle.Stop();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            audioSource.PlayOneShot(crashSound);
            GameManager.instance.GameOver = true;
        }
    }
}