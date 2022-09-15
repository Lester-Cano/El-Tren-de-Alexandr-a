using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlaceScript : MonoBehaviour
{
    ColorBoxPuzzle characteristic;
    ColorChecker parentZone;
    Transform myTransform;
    private bool isEqual;
    //Es de EXTREMA importancia que este array, y el de ColorBoxPuzzle sean del mismo tamaño, y tengan exactamente los mismos checks activados(los mismo elementos esten en true, y los mismo esten en false)
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
            if (isEqual)
            {
                other.attachedRigidbody.isKinematic = true;
                other.transform.parent = myTransform;
                other.transform.position = myTransform.position;
                //aumenta de 3 en tres?
                parentZone.actualValue++;
            }
            
        }
    }
}
