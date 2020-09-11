/*****************************************************************************
// File Name :         DestroyOutOfBounds.cs
// Author :            Kyle Grenier
// Creation Date :     September 08, 2020
//
// Brief Description : Destroys the attached gameObject when out of the designated bounds.
*****************************************************************************/
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 20f;
    public float bottomBound = -10f;

    private void Update()
    {
        //Separating the food from the animals going out of bounds.
        //Food goes out of bounds:
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        //Animal goes out of bounds:
        if (transform.position.z < bottomBound)
        {
            HealthManager.instance.TakeDamage();
            Destroy(gameObject);
        }
    }
}