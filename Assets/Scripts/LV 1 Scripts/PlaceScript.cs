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
    private void Start()
    {
        myTransform = GetComponent<Transform>();
        parentZone = GetComponentInParent<ColorChecker>();
    }
    private void OnTriggerEnter(Collider other )
    {
        if (other.GetComponent<ColorBoxPuzzle>() != null)
        {
            characteristic = other.GetComponent<ColorBoxPuzzle>();
            isEqual = correspondigPlace.SequenceEqual(characteristic.characteristics);
            if (isEqual && characteristic.pickedUp != true)
            {
                other.attachedRigidbody.isKinematic = true;
                other.transform.parent = childTransform;
                other.transform.position = childTransform.position;
                other.transform.rotation = childTransform.rotation;
                //aumenta de 3 en tres?
                parentZone.actualValue++;
            }
            
        }
    }
}
