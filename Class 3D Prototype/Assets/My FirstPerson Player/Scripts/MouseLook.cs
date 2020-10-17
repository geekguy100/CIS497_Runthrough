/*
 * Kyle Grenier
 * 3D Prototype
 * 
 * 10/16/2020
 * 
 * Description: Enables the player to look around by using the mouse.
 */

using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private GameObject player;
    private float verticalLookRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        //Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotate the player gameObject with horizontal mouse input.
        player.transform.Rotate(Vector3.up * mouseX);

        //Rotate the camera around the x axis with vertical mouse input.
        verticalLookRotation -= mouseY;

        //Clamp the rotation so the player does not over rotate and look behind them.
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        //Apply the clamped rotation.
        transform.localRotation = Quaternion.Euler(verticalLookRotation, 0, 0);
    }

    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}