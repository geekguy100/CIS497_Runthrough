/*****************************************************************************
// File Name :         RestartGame.cs
// Author :            Kyle Grenier
// Creation Date :     10/05/2020
//
// Brief Description : Allows player to restart game at any time by pressing designated key.
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private KeyCode restartKey = KeyCode.R;
    [SerializeField] private TextMeshProUGUI infoText;

    //Let the player know they can restart by pressing the key.
    private void Start()
    {
        infoText.text = "Press '" + restartKey + "' to restart at any time.";
        infoText.gameObject.SetActive(true);
        Invoke("HideText", 2f);
    }

    //Hide the text after some time.
    private void HideText()
    {
        infoText.gameObject.SetActive(false);
    }

    private void Update()
    {
        //If player presses restart key, reload the scene.
        if (Input.GetKeyDown(restartKey))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}