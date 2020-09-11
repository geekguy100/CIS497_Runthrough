/*****************************************************************************
// File Name :         DestroyOutOfBoundX.cs
// Author :            Kyle Grenier
// Creation Date :     9/10/20
//
// Brief Description : Destroys dogs if they are out of bounds on the X axis and balls if they fall below a certain y-coordinate value.
*****************************************************************************/
using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -30;
    private float bottomLimit = -5;

    // Update is called once per frame
    void Update()
    {
        // Destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // Destroy balls AND reduce lives if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            HealthManager.instance.TakeDamage();
            Destroy(gameObject);
        }

    }
}