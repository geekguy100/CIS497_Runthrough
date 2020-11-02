/*****************************************************************************
// File Name :         GroundCollider.cs
// Author :            Kyle Grenier
// Creation Date :     11/1/2020
//
// Brief Description :  Decrement score when a cube enters.
*****************************************************************************/
using UnityEngine;

public class GroundCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Cube"))
        {
            GameManager.Instance.Lives--;
            Destroy(col.gameObject);
        }
    }
}