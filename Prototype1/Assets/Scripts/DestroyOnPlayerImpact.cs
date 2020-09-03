using UnityEngine;

public class DestroyOnPlayerImpact : MonoBehaviour
{
    private bool hit = false;
    public float destroyTime = 3f;

    private void OnCollisionEnter(Collision col)
    {
        //If the colliding object is the player, destroy the box after some time.
        if (col.gameObject.CompareTag("Player") && !hit)
        {
            hit = true;
            Destroy(gameObject, destroyTime);
        }
    }
}