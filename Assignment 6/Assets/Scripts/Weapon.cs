/*****************************************************************************
// File Name :         Weapon.cs
// Author :            Kyle Grenier
// Creation Date :     11/1/2020
//
// Brief Description : Basic Weapon class.
*****************************************************************************/
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damageBonus;

    public Enemy enemyHoldingWeapon;

    private void Awake()
    {
        enemyHoldingWeapon = GetComponent<Enemy>();
    }

    protected void EnemyEatsWeapon()
    {
        Debug.Log("Enemy eats weapon.");
    }

    public void Recharge()
    {
        Debug.Log(gameObject.name + ": Recharging weapon.");
    }
}