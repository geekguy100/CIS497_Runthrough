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
        cam = GameObject.FindGameObjectWithTag("Camera").transform;
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

            //Extract the Target script from the hit object.
            Target target = hitInfo.transform.gameObject.GetComponent<Target>();
            //If the Target script was found, call the TakeDamage() method.
            if (target != null)
                target.TakeDamage(damage);

            //If the hit object has a rigidbody, apply the hit force to it.
            if (hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }
}
