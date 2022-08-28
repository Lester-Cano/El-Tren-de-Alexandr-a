using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Analize : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera gameCam, analizeCam;
    public GameObject objectToRotate;

    float rotationSpeed = 1f;

    private void Awake()
    {
        analizeCam.gameObject.SetActive(false);
    }
    public void GoToAnalize()
    {
        gameCam.gameObject.SetActive(false);
        analizeCam.gameObject.SetActive(true);
    }

    public void BackToGame()
    {
        analizeCam.gameObject.SetActive(false);
        gameCam.gameObject.SetActive(true);
    }

    public void OnMouseDrag()
    {
        float xAxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float yAxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

        objectToRotate.transform.Rotate(Vector3.down, xAxisRotation);
        objectToRotate.transform.Rotate(Vector3.down, yAxisRotation);
    }
}
