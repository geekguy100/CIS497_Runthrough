/*****************************************************************************
// File Name :         EnemyAI.cs
// Author :            Kyle Grenier
// Creation Date :     11/7/2020
// Assignment 7
// Brief Description : Script that controls enemy behaviour.
*****************************************************************************/
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;

    [SerializeField] private float speed = 5f;

    private Vector3 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            Debug.LogWarning("[Enemy]: Cannot find player GameObject!");
    }

    private void Update()
    {
        if (player != null)
            direction = (player.transform.position - transform.position).normalized;

        if (transform.position.y < -10f)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * speed);
    }
}