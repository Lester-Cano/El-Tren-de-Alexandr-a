using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTp : MonoBehaviour
{
    [SerializeField] GameObject[] Position;
    private GameObject playerTP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            playerTP = other.gameObject;
            Debug.Log("toque al vergas");
            
        }
    }

}
