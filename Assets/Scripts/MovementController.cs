using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{

    ThirdPersonActionsAssets TPInputActions;
    CharacterController characterController;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool movementPressed;
    [SerializeField] float speed;
    [SerializeField] float rotationPerFrame;

    void Awake()
    {

        TPInputActions = new ThirdPersonActionsAssets();
        characterController = GetComponent<CharacterController>();

        TPInputActions.Player.Move.started += OnMovementInput;
        TPInputActions.Player.Move.canceled += OnMovementInput;
        TPInputActions.Player.Move.performed += OnMovementInput;

    }

    void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        movementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void HandleRotation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;

        if (movementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationPerFrame);
        }
    }

    void HandleGravity()
    {
        if (characterController.isGrounded)
        {
            float groundedGravity = -0.5f;
            currentMovement.y = groundedGravity;
        }
        else
        {
            float gravity = -9.8f;
            currentMovement.y = gravity;
        }
    }

    void OnEnable()
    {
        TPInputActions.Player.Enable();
    }

    void OnDisable()
    {
        TPInputActions.Player.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleGravity();
        characterController.Move(currentMovement * Time.deltaTime *speed);
        
    }
}
