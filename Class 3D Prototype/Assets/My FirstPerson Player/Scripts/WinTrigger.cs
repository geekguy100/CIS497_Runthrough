/*
 * Kyle Grenier
 * 3D Prototype
 * 
 * 10/18/2020
 * 
 * Description: Displays win text when entered by player.
 */

using UnityEngine;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] GameObject winText;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            winText.SetActive(true);
        }
    }
}
