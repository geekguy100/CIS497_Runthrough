/*****************************************************************************
// File Name :         GameManager.cs
// Author :            Kyle Grenier
// Creation Date :     9/10/2020
//
// Brief Description : Manages the state of the game.
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private bool gameOver;
    public bool GameOver
    {
        get
        { return gameOver; }
    }
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject winText;

    public void OnGameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
    }

    public void OnGameWin()
    {
        gameOver = true;
        winText.SetActive(true);
    }

    private void Update()
    {
        //Press R to restart if game is over
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}