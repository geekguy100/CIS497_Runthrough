/*****************************************************************************
// File Name :         SoftCube.cs
// Author :            Kyle Grenier
// Creation Date :     11/1/2020
//
// Brief Description : ToughCube derives from Cube and is an easy to kill enemy.
*****************************************************************************/
using UnityEngine;

public class SoftCube : Cube
{
    protected override void Awake()
    {
        lives = 2;
        color = Color.green;
        base.Awake();
    }
}