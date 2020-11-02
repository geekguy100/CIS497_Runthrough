/*****************************************************************************
// File Name :         Golem.cs
// Author :            Kyle Grenier
// Creation Date :     11/1/2020
//
// Brief Description : An Enemy Golem class.
*****************************************************************************/
using UnityEngine;

public class Golem : Enemy
{
    protected int damage;

    protected override void Awake()
    {
        base.Awake();
        health = 120;
    }

    protected override void Attack(int amnt)
    {
        Debug.Log("Golem attacks!");
    }

    public override void TakeDamage(int amnt)
    {
        health -= amnt;
        print("Golem has taken " + amnt + " damage!");
    }
}