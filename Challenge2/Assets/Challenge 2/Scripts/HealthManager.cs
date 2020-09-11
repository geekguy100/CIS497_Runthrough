/*****************************************************************************
// File Name :         HealthManager.cs
// Author :            Kyle Grenier
// Creation Date :     September 10, 2020
//
// Brief Description : Script that manages the player's health.
*****************************************************************************/
//This script is based on https://www.youtube.com/watch?v=3uyolYVsiWc
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : Singleton<HealthManager>
{
    public int health;
    public int maxHealth;

    public List<Image> hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        //Make sure maxHealth is NOT more than the amount of hearts on the screen; This would cause hearts to update incorrectly.
        if (maxHealth > hearts.Count)
            maxHealth = hearts.Count;

        //If the health is above the maxHealth for some reason, make sure it's capped at the maxHealth.
        if (health > maxHealth)
            health = maxHealth;
    }

    void Update()
    {
        //If the game is already over, don't run any of the following code.
        if (GameManager.instance.GameOver)
            return;

        for (int i = 0; i < hearts.Count; i++)
        {
            //Display full or empty heart sprite based on current health
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            //Show the number of hearts equal to current max health
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        //Loss condition is all health is lost.
        if (health <= 0)
            GameManager.instance.OnGameOver();

    }

    public void TakeDamage()
    {
        health--;
    }
}