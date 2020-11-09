/*****************************************************************************
// File Name :         SpawnManager.cs
// Author :            Kyle Grenier
// Creation Date :     11/7/2020
// Assignment 7
// Brief Description : Enemy spawning behaviour.
*****************************************************************************/
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab = null;
    [SerializeField] private GameObject powerupPrefab = null;

    private float spawnRange = 9f;

    private int enemyCount = 0;
    private int waveNumber = 0;

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup(int powerupsToSpawn)
    {
        for (int i = 0; i < powerupsToSpawn; i++)
        {
            Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
    }

    private void Update()
    {
        //If the game hasnt started or is over, don't spawn enemies.
        if (!GameManager.Instance.GameStarted || GameManager.Instance.GameOver)
            return;

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0)
        {
            waveNumber++;

            //If the game has been won; player survived through the winning number of waves.
            if (waveNumber >= GameManager.Instance.WinningWave + 1)
            {
                GameManager.Instance.GameWon = true;
                return;
            }

            SpawnEnemyWave(waveNumber);
            SpawnPowerup(1);
            GameManager.Instance.UpdateWaveText(waveNumber);
        }
    }
}