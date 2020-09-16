/*****************************************************************************
// File Name :         SpawnManager.cs
// Author :            Kyle Grenier
// Creation Date :     September 15, 2020
// Assignment:         #4
//
// Brief Description : Script that manages spawning obstacles in the game.
*****************************************************************************/
using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    private Vector3 spawnPos = new Vector3(25,0,0);

    private float startDelay = 2f;
    private float repeatDelay = 2f;

    private void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(startDelay);
        while (!GameManager.instance.GameOver)
        {
            Instantiate(prefab, spawnPos, prefab.transform.rotation);
            yield return new WaitForSeconds(repeatDelay);
        }
    }
}