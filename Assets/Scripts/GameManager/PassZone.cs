using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassZone : MonoBehaviour
{
    [SerializeField] private GameObject pos;
    private GameObject objectToMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            objectToMove = other.gameObject;
            StartCoroutine(Teleport());
        }

        
    }

    private IEnumerator Teleport()
    {
        if (objectToMove != null)
        {
            pos.SetActive(false);
            objectToMove.transform.position = pos.transform.position;

            yield return new WaitForSeconds(2f);

            pos.SetActive(true);
        }
    }
}
