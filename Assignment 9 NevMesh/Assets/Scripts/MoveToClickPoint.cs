/*****************************************************************************
// File Name :         MoveToClickPoint.cs
// Author :            Kyle Grenier
// Creation Date :     12/13/2020
//
// Brief Description : Moves the NavMeshAgent to the clicked point.
*****************************************************************************/
using UnityEngine;
using UnityEngine.AI;

public class MoveToClickPoint : MonoBehaviour
{
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.destination = hit.point;
            }
        }
    }
}