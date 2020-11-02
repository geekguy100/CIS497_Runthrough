/*****************************************************************************
// File Name :         ToughCube.cs
// Author :            Kyle Grenier
// Creation Date :     11/1/2020
//
// Brief Description : ToughCube derives from Cube and is a harder to kill enemy.
*****************************************************************************/
using UnityEngine;

public class ToughCube : Cube
{
    protected override void Awake()
    {
        lives = 2;
        color = Color.blue;
        base.Awake();
    }
}