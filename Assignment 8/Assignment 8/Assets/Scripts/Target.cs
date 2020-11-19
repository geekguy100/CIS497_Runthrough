/*****************************************************************************
// File Name :         Target.cs
// Author :            Kyle Grenier
// Creation Date :     11/17/2020
// Assignment 8
// Brief Description : Controls behaviour of in-game targets.
*****************************************************************************/
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    private Rigidbody rb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float minTorque = -10;
    private float maxTorque = 10;

    private float xRange = 4;
    private float ySpawnPos = -6;

    [SerializeField] private int pointValue = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(minTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange,xRange), ySpawnPos);
    }

    /// <summary>
    /// Destroy the target on mouse click.
    /// </summary>
    private void OnMouseDown()
    {
        GameManager.Instance.Score += pointValue;
        Destroy(gameObject);
    }

    /// <summary>
    /// Destroy the target upon entering the Sensor trigger; the only trigger in the scene.
    /// </summary>
    private void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}