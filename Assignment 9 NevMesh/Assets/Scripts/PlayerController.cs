/*****************************************************************************
// File Name :         PlayerController.cs
// Author :            Kyle Grenier
// Creation Date :     12/13/2020
//
// Brief Description : Script to control the behvaiour of the player.
*****************************************************************************/
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    private ThirdPersonCharacter character;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
    }

    private void Start()
    {
        agent.updateRotation = false; //Turn this to false b/c we'll let the ThirdPersonCharacter handle it.
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

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }
}