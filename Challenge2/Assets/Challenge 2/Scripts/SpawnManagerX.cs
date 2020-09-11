/*****************************************************************************
// File Name :         SpawnManagerX.cs
// Author :            Kyle Grenier
// Creation Date :     9/10/20
//
// Brief Description : Randomly spawns ball prefabs within a boundry on the X-axis.
*****************************************************************************/
using UnityEngine;
using System.Collections;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;

    private void Start()
    {
        StartCoroutine(LoopSpawns());
    }

    //For as long as the game is in session, continue to spawn random balls.
    private IEnumerator LoopSpawns()
    {
        yield return new WaitForSeconds(startDelay);
        while(!GameManager.instance.GameOver)
        {
            SpawnRandomBall();
            float spawnInterval = Random.Range(3, 5);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        //Generate a random index
        int index = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[index], spawnPos, ballPrefabs[index].transform.rotation);
    }

}
