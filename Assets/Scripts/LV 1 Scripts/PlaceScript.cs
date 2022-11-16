using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlaceScript : MonoBehaviour
{
    ColorBoxPuzzle characteristic;
    ColorChecker parentZone;
    Transform myTransform;
    [SerializeField] Transform childTransform;
    private bool isEqual;

    [SerializeField] bool[] correspondigPlace;

    [SerializeField] private int checker = 0;

    private void Start()
    {
        myTransform = GetComponent<Transform>();
        parentZone = GetComponentInParent<ColorChecker>();
        checker = 0;
    }
    private void OnTriggerEnter(Collider other )
    {
        if (other.GetComponent<ColorBoxPuzzle>() != null && checker < 1)
        {
            characteristic = other.GetComponent<ColorBoxPuzzle>();

            if(characteristic.pickedUp != true)
            {
                isEqual = correspondigPlace.SequenceEqual(characteristic.characteristics);
                if (isEqual)
                {
                    other.attachedRigidbody.isKinematic = true;
                    other.transform.parent = childTransform;
                    other.transform.position = childTransform.position;
                    other.transform.rotation = childTransform.rotation;

                    Collider[] colliders = other.GetComponents<Collider>();
                    foreach(var col in colliders)
                    {
                        col.enabled = false;
                    }

                    checker++;
                    parentZone.actualValue++;
                }
            }
        }
    }
}
