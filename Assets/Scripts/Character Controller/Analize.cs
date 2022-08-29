using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class Analize : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera gameCam, analizeCam;
    public GameObject objectToRotate, pivot, canvas;

    float rotationSpeed = 1f;

    //Input area
    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interaction;

    CharacterMechanics characterMechanics;
    ThirdPersonController controller;

    private void Awake()
    {
        analizeCam.gameObject.SetActive(false);
        playerActionsAssets = new ThirdPersonActionsAssets();
        characterMechanics = GetComponent<CharacterMechanics>();
        controller = GetComponent<ThirdPersonController>();
    }
    private void Start()
    {
        OnDisable();
    }

    private void OnEnable()
    {
        interaction = playerActionsAssets.Player.Interact;
        playerActionsAssets.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionsAssets.Player.Disable();
    }

    private void Update()
    {
        if (playerActionsAssets.Player.Rotate.IsPressed())
        {
            float xAxisRotation = playerActionsAssets.Player.MouseX.ReadValue<float>() * rotationSpeed;
            float yAxisRotation = playerActionsAssets.Player.MouseY.ReadValue<float>() * rotationSpeed;

            objectToRotate.transform.Rotate(Vector3.up, xAxisRotation);
            objectToRotate.transform.Rotate(Vector3.left, yAxisRotation);
        }
    }

    public void GoToAnalize(GameObject target)
    {
        OnEnable();

        var newObject = Instantiate(target, pivot.transform.position, Quaternion.identity);
        objectToRotate = newObject;

        gameCam.gameObject.SetActive(false);
        analizeCam.gameObject.SetActive(true);

        canvas.SetActive(true);

        characterMechanics.OnDisable();
        controller.OnDisable();
    }

    public void BackToGame()
    {
        analizeCam.gameObject.SetActive(false);
        gameCam.gameObject.SetActive(true);

        OnDisable();
        characterMechanics.OnEnable();
        controller.OnEnable();
    }
}
