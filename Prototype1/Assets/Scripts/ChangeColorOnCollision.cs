using UnityEngine;

public class ChangeColorOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        //When the player collides with this obstacle.
        if (col.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
