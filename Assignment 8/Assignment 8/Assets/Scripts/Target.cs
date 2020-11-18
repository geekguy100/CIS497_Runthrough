/*****************************************************************************
// File Name :         Target.cs
// Author :            Kyle Grenier
// Creation Date :     11/17/2020
// Assignment 8
// Brief Description : ADD BRIEF DESCRIPTION OF THE FILE HERE
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
}