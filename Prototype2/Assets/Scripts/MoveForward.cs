/*****************************************************************************
// File Name :         MoveForward.cs
// Author :            Kyle Grenier
// Creation Date :     September 08, 2020
//
// Brief Description : Translates a game object forward at a set speed.
*****************************************************************************/
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40f;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}