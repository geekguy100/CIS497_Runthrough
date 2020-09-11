/*****************************************************************************
// File Name :         DetectCollisions.cs
// Author :            Kyle Grenier
// Creation Date :     September 08, 2020
//
// Brief Description : Destroys this gameObject and the colliding gameObject upon collision.
*****************************************************************************/
using UnityEngine;

//Attach this to the food projective prefab.
public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        ScoreManager.instance.Score++;
        Destroy(col.gameObject);
        Destroy(gameObject);
    }
}