/*****************************************************************************
// File Name :         PlayerControllerX.cs
// Author :            Kyle Grenier
// Creation Date :     9/10/2020
//
// Brief Description : Allows for control of the player.
*****************************************************************************/

using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float timeBetweenDogSpawns = 0.5f;
    private float nextSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        //If the game is over, don't run the following code.
        if (GameManager.instance.GameOver)
            return;

        // On spacebar press, send dog with added delay in between possible spawns. Makes sure the player cannot spawn spawn dogs.
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + timeBetweenDogSpawns;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}