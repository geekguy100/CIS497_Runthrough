/*****************************************************************************
// File Name :         ShootPrefab.cs
// Author :            Kyle Grenier
// Creation Date :     September 08, 2020
//
// Brief Description : Enables firing a prefab upon a button press.
*****************************************************************************/
using UnityEngine;

public class ShootPrefab : MonoBehaviour
{
    //The prefab we want to shoot.
    public GameObject prefabToShoot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabToShoot, transform.position, prefabToShoot.transform.rotation);
        }
    }
}