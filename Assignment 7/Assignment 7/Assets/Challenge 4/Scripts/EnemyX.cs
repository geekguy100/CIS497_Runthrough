using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    // Start is called before the first frame update
    void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        playerGoal = GameObject.FindGameObjectWithTag("PlayerGoal");
        speed = SpawnManagerX.enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Don't move enemies if the game hasn't started or it's over.
        if (!GameManager.Instance.GameStarted || GameManager.Instance.GameOver)
            return;

        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.CompareTag("EnemyGoal"))
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.CompareTag("PlayerGoal"))
        {
            other.gameObject.GetComponent<PlayerGoalBehaviour>().EnemiesEnteredThisWave++;
            Destroy(gameObject);
        }

    }
}