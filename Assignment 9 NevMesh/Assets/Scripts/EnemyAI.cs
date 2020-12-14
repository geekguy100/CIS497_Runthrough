/*****************************************************************************
// File Name :         EnemyAI.cs
// Author :            Kyle Grenier
// Creation Date :     12/13/2020
//
// Brief Description : Controls the enemy's behaviour
*****************************************************************************/
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private ThirdPersonCharacter character;

    private GameObject player;

    public float chaseDistance = 8.0f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
    }

    private void Start()
    {
        agent.updateRotation = false; //Turn this to false b/c we'll let the ThirdPersonCharacter handle it.
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        float distanceFromTarget = Vector3.Distance(transform.position, player.transform.position);

        if (distanceFromTarget > agent.stoppingDistance && distanceFromTarget < chaseDistance)
        {
            agent.SetDestination(player.transform.position);
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            agent.SetDestination(transform.position);
            character.Move(Vector3.zero, false, false);
        }
    }
}