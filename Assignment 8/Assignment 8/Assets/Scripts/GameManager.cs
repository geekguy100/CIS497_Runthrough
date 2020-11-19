/*****************************************************************************
// File Name :         GameManager.cs
// Author :            Kyle Grenier
// Creation Date :     11/17/2020
//
// Brief Description : A GameManager class to handle the game state and spawning objects.
*****************************************************************************/
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<GameObject> targets;
    private float spawnRate = 1f;

    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            //Wait 1 second.
            yield return new WaitForSeconds(spawnRate);

            //Pick a random index betwwen 0 and number of prefabs.
            int index = Random.Range(0, targets.Count);

            //Spawn prefab at random index.
            Instantiate(targets[index]);
        }
    }

    void Update()
    {
        
    }
}