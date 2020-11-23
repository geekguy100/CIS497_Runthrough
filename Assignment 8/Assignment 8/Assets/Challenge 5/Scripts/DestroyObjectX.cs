/*
 *  Assignment 8 Challenge
 *  Kyle Grenier
 *  11/22/2020
 *  
 *  Destroys a game object after time. Used for destroying particles after time.
 */

using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2); // destroy particle after 2 seconds
    }


}
