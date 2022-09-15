using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    [SerializeField] GameObject keyObject;
    [SerializeField] int valueToGet;
    public int actualValue;

    private void Start()
    {
        keyObject.SetActive(false);
    }
}
