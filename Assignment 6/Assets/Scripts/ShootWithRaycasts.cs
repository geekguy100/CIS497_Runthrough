/*
 * Kyle Grenier
 * 3D Prototype
 * 
 * 10/17/2020
 * 
 * Description: Enables player to shoot with raycasts.
 */

using UnityEngine;

public class ShootWithRaycasts : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float hitForce = 10f;
    [SerializeField] private float range = 100f;
    private Transform cam;

    [SerializeField] private ParticleSystem muzzleFlash;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    private void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hitInfo;
        //If we hit something with our ray...
        if (Physics.Raycast(cam.position, cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);

            //Get the Cube script from the hit object.
            Cube c = hitInfo.transform.GetComponent<Cube>();
            if (c != null)
                c.TakeDamage(1);

            //If the hit object has a rigidbody, apply the hit force to it.
            if (hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }
}
