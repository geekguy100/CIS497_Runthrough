/*****************************************************************************
// File Name :         PropellerSpin.cs
// Author :            Kyle Grenier
// Creation Date :     September 06, 2020
// Assignment #2
//
// Brief Description : Spins the plane's propeller at a set rotation speed.
*****************************************************************************/
using UnityEngine;

public class PropellerSpin : MonoBehaviour
{
    public float rotationSpeed = 2000f;

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}