/*****************************************************************************
// File Name :         GameManager.cs
// Author :            Kyle Grenier
// Creation Date :     11/1/2020
//
// Brief Description : GameManager class to handle game state.
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    //Keeps track of the current level.
    private string currentLevelName = string.Empty;
    public int score = 0;

    [SerializeField] private GameObject pauseMenu;

    private bool paused;

    protected override void Awake()
    {
        base.Awake();
        paused = pauseMenu.activeInHierarchy;
    }

    //Methods to load and unload the scene.
    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
        if (ao == null)
        {
            Debug.LogError("[GameManager]: Unable to load level " + levelName + ".");
            return;
        }

        currentLevelName = levelName;
    }

    public void UnloadLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(currentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager]: Unable to unload level " + currentLevelName + ".");
            return;
        }
    }

    //Pausing and unpausing.
    public void Pause()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }
}