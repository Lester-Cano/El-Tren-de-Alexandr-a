using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPuzzle : MonoBehaviour
{
    [SerializeField] GameObject[] Positions;

    private CharacterController characterController;
    private GameObject player;

    public delegate void MazeEvents();
    public event MazeEvents MazeCompleted;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        characterController = player.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Z1Next")) {
            characterController.enabled = false;
            player.transform.position = Positions[1].transform.position;
            characterController.enabled = true;
        }
        if (other.CompareTag("Z2Next")) {
            characterController.enabled = false;
            player.transform.position = Positions[2].transform.position;
            characterController.enabled = true;
        }
        if (other.CompareTag("Z3Next")) {
            characterController.enabled = false;
            player.transform.position = Positions[3].transform.position;
            characterController.enabled = true;
        }
        if (other.CompareTag("Z4Next")) {
            characterController.enabled = false;
            player.transform.position = Positions[4].transform.position;
            characterController.enabled = true;
        }
        if (other.CompareTag("Z5Next"))
        {
            characterController.enabled = false;
            player.transform.position = Positions[5].transform.position;
            characterController.enabled = true;

            MazeCompleted?.Invoke();
        }
        if (other.CompareTag("Z1Back")) {
            characterController.enabled = false;
            player.transform.position = Positions[0].transform.position;
            characterController.enabled = true;
        }
    }
}
