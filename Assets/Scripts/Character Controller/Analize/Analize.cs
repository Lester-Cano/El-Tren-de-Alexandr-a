using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class Analize : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera gameCam, analizeCam;
    public GameObject objectToRotate, pivot, canvas;

    public float rotationSpeed = 100f;

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
        playerActionsAssets.Player.Rotate.Disable();
    }

    private void Update()
    {
        if (playerActionsAssets.Player.Rotate.IsPressed())
        {
            Vector2 deltaAxisRotation = playerActionsAssets.Player.MouseDrag.ReadValue<Vector2>() * rotationSpeed * Time.deltaTime;

            var finalRotation = Quaternion.Euler(deltaAxisRotation.x, 0, 0) * Quaternion.Euler(0, 0, deltaAxisRotation.y);
            objectToRotate.transform.localRotation *= finalRotation;
        }

        if (playerActionsAssets.Player.ZoomIn.IsPressed())
        {

        }

        if (playerActionsAssets.Player.ZoomOut.IsPressed())
        {

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
