using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* Kyle Grenier
* Assignment 2
* Manages score and updates cooresponding properties and components
* related to the score.
*/

public class ScoreManager : Singleton<ScoreManager>
{
    public int score = 0;
    public int winningScore = 5;
    private bool gameWon = false;
    private bool gameOver = false;

    public Text gameStatusTextbox;
    public Text scoreTextbox;

    //Reset variables to default on game start.
    private void Start()
    {
        OnGameStart();
    }

    //Reset all variables to default so score and text won't carry over from previous plays.
    private void OnGameStart()
    {
        print("SCORE MANAGER: Defaulting variables...");
        score = 0;
        gameWon = false;
        gameOver = false;
    }

    private void Update()
    {
        //When the game is over, allow the player to restart the game by pressing 'R'.
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //Adds 'int s' to the current score and updates the appropriate text. Used to increase the player's score.
    public void AddToScore(int s)
    {
        score += s;
        scoreTextbox.text = score.ToString();
        CheckForWin();
    }

    //Checks to see if the player won the game and displays text if they have.
    private void CheckForWin()
    {
        if (score >= winningScore)
        {
            gameWon = true;
            gameOver = true;

            gameStatusTextbox.text = "You win!\nPress R to Try Again!";
        }
    }

    //Change the text on game loss to notify player of their failure.
    public void OnGameLoss()
    {
        //Notify the player they lost, assumming they haven't already won.
        if (!gameWon)
        {
            gameOver = true;
            gameStatusTextbox.text = "You lose!\nOut of Bounds!\nPress R to Try Again!";
        }
    }
}