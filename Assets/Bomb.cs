using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform startPosition;

    private void Start()
    {
        startPosition = transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            collision.gameObject.SetActive(false);
            transform.position = startPosition.position;
        }
    }


}
