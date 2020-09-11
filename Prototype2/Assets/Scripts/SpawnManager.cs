/*****************************************************************************
// File Name :         SpawnManager.cs
// Author :            Kyle Grenier
// Creation Date :     September 10, 2020
//
// Brief Description : Script that manages the spawning of enemies.
*****************************************************************************/
using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    //Drag the prefabs to spawn onto this array in the inspector.
    public GameObject[] prefabsToSpawn;

    private float leftBound = -14;
    private float rightBound = 14;
    private float zSpawnPos = 20;

    private void Start()
    {
        StartCoroutine(LoopSpawns());
    }

    private IEnumerator LoopSpawns()
    {
        //Wait 3 seconds before beginning to spawn enemies.
        yield return new WaitForSeconds(3f);

        while (!HealthManager.instance.gameOver)
        {
            SpawnRandomPrefab();
            float randomDelay = Random.Range(0.8f, 2.0f);

            yield return new WaitForSeconds(randomDelay);
        }
    }

    private void SpawnRandomPrefab()
    {
        //Generate a random index.
        int index = Random.Range(0, prefabsToSpawn.Length);

        //Generate a spawn pos
        Vector3 pos = new Vector3(Random.Range(leftBound, rightBound), 0, zSpawnPos);

        //Spawn the prefab at location
        Instantiate(prefabsToSpawn[index], pos, prefabsToSpawn[index].transform.rotation);
    }
}