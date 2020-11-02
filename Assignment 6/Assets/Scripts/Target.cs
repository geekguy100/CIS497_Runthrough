/*
 * Kyle Grenier
 * 3D Prototype
 * 
 * 10/18/2020
 * 
 * Description: A Target script that contains health. Health is depleted when hit from a raycast by the player.
 */

using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float health = 50f;

    public void TakeDamage(float amnt)
    {
        health -= amnt;
        if (health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
