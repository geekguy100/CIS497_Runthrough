/*****************************************************************************
// File Name :         Cube.cs
// Author :            Kyle Grenier
// Creation Date :     11/1/2020
//
// Brief Description : A basic Cube script. The "enemy" of the game.
*****************************************************************************/
using UnityEngine;
using System.Collections;

public abstract class Cube : MonoBehaviour, IDamageable
{
    protected int lives;
    protected Color color;

    protected virtual void Awake()
    {
        GetComponent<Renderer>().material.color = color;
    }

    public void TakeDamage(int amnt)
    {
        lives -= amnt;
        if (lives <= 0)
        {
            GameManager.Instance.Score++;
            Destroy(gameObject);
        }
    }
}