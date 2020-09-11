/*****************************************************************************
// File Name :         MoveForwardX.cs
// Author :            Kyle Grenier
// Creation Date :     9/10/2020
//
// Brief Description : Moves a Transform in the forward direction with a set speed.
*****************************************************************************/
using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
