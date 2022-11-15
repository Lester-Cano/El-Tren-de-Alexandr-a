using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePS : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.forward * 0.3f, Space.World);
    }
}
