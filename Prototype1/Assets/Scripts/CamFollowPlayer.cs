using UnityEngine;

/*
* Kyle Grenier
* Assignment 2
* Makes the camera follow the player.
*/

public class CamFollowPlayer : MonoBehaviour
{
    public GameObject player;

    public float smoothTime = 0f;
    private Vector3 offset = new Vector3(0,5,-10);
    private Vector3 vel = Vector3.zero;

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref vel, smoothTime);
    }
}
