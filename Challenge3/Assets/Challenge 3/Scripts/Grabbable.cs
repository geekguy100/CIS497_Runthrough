/*****************************************************************************
// File Name :         Grabbable.cs
// Author :            Kyle Grenier
// Creation Date :     9/21/2020
// Assignment:         Challenge 3
// Brief Description : Simple script to change the amount of points (in the inspector) grabbables give the player.
//                     Also used by player game object to tell the score manager how many points they received.
*****************************************************************************/
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    [SerializeField] private int points = 5;
    public int Points
    {
        get { return points; }
    }
}