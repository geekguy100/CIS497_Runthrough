/*****************************************************************************
// File Name :         MoveTo.cs
// Author :            Kyle Grenier
// Creation Date :     12/13/2020
//
// Brief Description : Moves a NavMeshAgent to a target. Taken from Unity Docs.
*****************************************************************************/
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public Transform goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}