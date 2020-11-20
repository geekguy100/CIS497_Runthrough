/*****************************************************************************
// File Name :         DifficultyButton.cs
// Author :            Kyle Grenier
// Creation Date :     11/20/2020
// Assignment 8
// Brief Description : Behaviour for clicking difficulty buttons to start the game.
*****************************************************************************/
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    [SerializeField] private int difficulty = 1;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        GameManager.Instance.StartGame(difficulty);
    }
}