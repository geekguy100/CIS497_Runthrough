/*****************************************************************************
// File Name :         RotateCamera.cs
// Author :            Kyle Grenier
// Creation Date :     11/7/2020
// Assignment 7
// Brief Description : Rotate the camera around focal point.
*****************************************************************************/
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private void Update()
    {
        if (GameManager.Instance.GameOver)
            return;

        float horizonal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizonal * rotationSpeed * Time.deltaTime);
    }
}