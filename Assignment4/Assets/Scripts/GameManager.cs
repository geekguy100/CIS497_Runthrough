/*****************************************************************************
// File Name :         GameManager.cs
// Author :            Kyle Grenier
// Creation Date :     September 15, 2020
// Assignment:         #4
// Brief Description : Simple game manager script that manages the game's state.
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private bool gameOver = false;
    public bool GameOver
    {
        //Return the gameOver value.
        get { return gameOver; }
        //Set gameOver to the given value. If the player lost the game, display OnGameLoss text.
        set
        {
            gameOver = value;
            if (gameOver && !gameWon)
                UIManager.instance.OnGameLoss();

            if (!gameOver)
                gameWon = false;
        }
    }

    private bool gameWon = false;
    public bool GameWon
    {
        //Return the gameWon value.
        get { return gameWon; }
        //Set the gameWon value. If gameWon, gameOver is also true, so we set that.
        //If the player won, display OnGameWin text.
        set
        {
            gameWon = value;
            if (gameWon)
            {
                gameOver = true;
                UIManager.instance.OnGameWon();
            }

        }
    }

    private void Update()
    {
        //If the game is over, allow the player to restart.
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}