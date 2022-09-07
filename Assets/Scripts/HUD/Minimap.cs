using UnityEngine;
using System.Collections;

public class Minimap : MonoBehaviour
{
    public Transform Target;
    public float speed = 2.0f;
    void Update()
    {
        float Interpolation = speed * Time.deltaTime;
        Vector3 position = transform.position;
        position.x = Mathf.Lerp(transform.position.x, Target.position.x, Interpolation);
        position.z = Mathf.Lerp(transform.position.z, Target.position.z, Interpolation);
        transform.position = position;
    }
}
