using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPuzzle : MonoBehaviour
{
    [SerializeField] GameObject[] Positions;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Z1Next")) {
            this.transform.position = Positions[1].transform.position;
        }
        if (other.CompareTag("Z2Next")) {
            this.transform.position = Positions[2].transform.position;
        }
        if (other.CompareTag("Z3Next")) {
            this.transform.position = Positions[3].transform.position;
        }
        if (other.CompareTag("Z4Next")) {
            this.transform.position = Positions[4].transform.position;
        }
        else if (other.CompareTag("Z1Back")) {
            this.transform.position = Positions[0].transform.position;
        }
    }
}
