/*****************************************************************************
// File Name :         Enemy.cs
// Author :            Kyle Grenier
// Creation Date :     11/1/2020
//
// Brief Description : A parent Enemy class.
*****************************************************************************/
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected float speed;
    protected int health;

    protected Weapon weapon;

    protected virtual void Awake()
    {
        weapon = gameObject.AddComponent<Weapon>();

        speed = 5f;
        health = 100;
    }

    protected abstract void Attack(int amnt);
    public abstract void TakeDamage(int amnt);
}