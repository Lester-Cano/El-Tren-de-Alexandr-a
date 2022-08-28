using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class Analize : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera gameCam, analizeCam;
    public GameObject objectToRotate;

    float rotationSpeed = 1f;

    //Input area
    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interact;

    private void Awake()
    {
        analizeCam.gameObject.SetActive(false);
        playerActionsAssets = new ThirdPersonActionsAssets();
    }

    private void OnEnable()
    {
        interact = playerActionsAssets.Player.Interact;
        playerActionsAssets.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionsAssets.Player.Disable();
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

    public void OnMouseDrag(GameObject target)
    {
        objectToRotate = target;

        float xAxisRotation = playerActionsAssets.Player.MouseX.ReadValue<float>() * rotationSpeed;
        float yAxisRotation = playerActionsAssets.Player.MouseY.ReadValue<float>() * rotationSpeed;
        Debug.Log(xAxisRotation);

        objectToRotate.transform.Rotate(Vector3.down, xAxisRotation);
        objectToRotate.transform.Rotate(Vector3.down, yAxisRotation);
    }
}
