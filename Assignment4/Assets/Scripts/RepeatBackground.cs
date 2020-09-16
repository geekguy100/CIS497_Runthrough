/*****************************************************************************
// File Name :         RepeatBackground.cs
// Author :            Kyle Grenier
// Creation Date :     September 15, 2020
// Assignment:         #4
// Brief Description : Repeats the background to make it appear endless.
*****************************************************************************/
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    void Start()
    {
        //Save the start position of the background as a Vector3.
        startPos = transform.position;

        //Set the repeatWidth to half the width of the background using the BoxCollider.
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    private void Update()
    {
        //If the background is further to the left than the repeatWidth, reset it to its startPos.
        if (transform.position.x < startPos.x - repeatWidth)
            transform.position = startPos;
    }
}