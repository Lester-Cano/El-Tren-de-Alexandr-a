using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPuzzle : MonoBehaviour
{
    [SerializeField] GameObject[] Positions;
    private GameObject player;

    public delegate void MazeEvents();
    public event MazeEvents MazeCompleted;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Z1Next")) {
            player.transform.position = Positions[1].transform.position;
        }
        if (other.CompareTag("Z2Next")) {
            player.transform.position = Positions[2].transform.position;
        }
        if (other.CompareTag("Z3Next")) {
            player.transform.position = Positions[3].transform.position;
        }
        if (other.CompareTag("Z4Next")) {
            player.transform.position = Positions[4].transform.position;

            MazeCompleted?.Invoke();
        }
        else if (other.CompareTag("Z1Back")) {
            player.transform.position = Positions[0].transform.position;
        }
    }
}
