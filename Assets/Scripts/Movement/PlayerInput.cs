using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, IInput
{
    ThirdPersonActionsAssets TPInputActions;

    Vector2 currentMovementInput;

    public Action<Vector2> OnMovementInput { get; set; }
    public Action<Vector3> OnMovementDirectionInput { get; set; }

    private void Awake()
    {
        TPInputActions = new ThirdPersonActionsAssets();

        TPInputActions.Player.Move.started += OnMovementInputFromNI;
        TPInputActions.Player.Move.canceled += OnMovementInputFromNI;
        TPInputActions.Player.Move.performed += OnMovementInputFromNI;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnEnable()
    {
        TPInputActions.Player.Enable();
    }

    public void OnDisable()
    {
        TPInputActions.Player.Disable();
    }

    void Update()
    {
        GetMovementInput();
        GetMovementDirection();
    }

    private void GetMovementInput()
    {
        Vector2 input = new Vector2(currentMovementInput.x, currentMovementInput.y);
        OnMovementInput?.Invoke(input);
    }

    private void GetMovementDirection()
    {
        var cameraForwardToDirection = Camera.main.transform.forward;
        Debug.DrawRay(Camera.main.transform.position, cameraForwardToDirection * 10, Color.red);
        var directionToMoveIn = Vector3.Scale(cameraForwardToDirection, (Vector3.right + Vector3.forward));
        Debug.DrawRay(Camera.main.transform.position, directionToMoveIn * 10, Color.blue);
        OnMovementDirectionInput?.Invoke(directionToMoveIn);
    }

    void OnMovementInputFromNI(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
    }
}
