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
using UnityEngine.SceneManagement;

public class HealthManager : Singleton<HealthManager>
{
    public int health;
    public int maxHealth;

    public List<Image> hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public bool gameOver = false;

    public GameObject gameOverText;

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

        if (health <= 0)
        {
            gameOver = true;
            gameOverText.SetActive(true);

            //Press R to restart if game is over
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    public void TakeDamage()
    {
        health--;
    }

    public void AddMaxHealth()
    {
        maxHealth++;
    }
}