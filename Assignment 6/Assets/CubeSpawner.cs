/*****************************************************************************
// File Name :         CubeSpawner.cs
// Author :            Kyle Grenier
// Creation Date :     11/1/2020
//
// Brief Description : Spawns cubes within a boundary.
*****************************************************************************/
using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] cubePrefabs;
    private float minX = 0, minZ = 0, maxX = 0, maxZ = 0;

    private void Awake()
    {
        //Variable initialization.
        float x = transform.localScale.x;
        float z = transform.localScale.z;

        minX = -x;
        maxX = x;
        minZ = -z;
        maxZ = z;
    }

    /// <summary>
    /// Public method to start spawning cubes.
    /// </summary>
    public void StartSpawning()
    {
        StartCoroutine(Spawn());
    }

    /// <summary>
    /// Spawns cubes according to level difficulty, the TimeBetweenSpawns.
    /// </summary>
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3f);
        while (!GameManager.Instance.GameOver)
        {
            SpawnCube();
            yield return new WaitForSeconds(GameManager.Instance.TimeBetweenSpawns);
        }
    }

    /// <summary>
    /// Spawns a cube
    /// </summary>
    void SpawnCube()
    {
        float x, y, z;
        x = Random.Range(minX, maxX);
        z = Random.Range(minZ, maxZ);
        y = transform.position.y;

        Vector3 pos = new Vector3(x,y,z);

        int i = Random.Range(0, cubePrefabs.Length - 1);

        Rigidbody cube = Instantiate(cubePrefabs[i], pos, Quaternion.identity).GetComponent<Rigidbody>();
    }
}