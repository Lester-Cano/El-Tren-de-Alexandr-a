using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    CharacterController controller;
    public float rotationSpeed, movementSpeed, gravity = 20;

    Vector3 movementVector = Vector3.zero;
    private float desiredRotationAngle = 0;

    //Events to trigger the minimap tween

    public delegate void OnNotmoving(bool state);
    public event OnNotmoving onNotmoving;

    //variable to count the time when the player is not moving

    float tweenTimer = 0;
    [SerializeField] public float tweenLimit;
    bool isFadded;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            if(movementVector.magnitude > 0)
            {
                RotateAgent();
            }
        }
        movementVector.y -= gravity;
        controller.Move(movementVector * Time.deltaTime);
    }

    public void HandleMovement(Vector2 input)
    {
        if (controller.isGrounded)
        {
            if(input.y > 0)
            {
                movementVector = transform.forward * movementSpeed;

                if (isFadded)
                {
                    if (onNotmoving != null)
                    {
                        onNotmoving(false);
                        isFadded = false;
                        tweenTimer = 0;
                    }
                }
            }
            else
            {
                movementVector = Vector3.zero;

                tweenTimer += Time.deltaTime;

                if (tweenTimer >= tweenLimit)
                {
                    if (onNotmoving != null)
                    {
                        onNotmoving(true);
                        tweenTimer = 0;
                        isFadded = true;
                    }
                }
            }
        }
    }

    public void HandleMovementDirection(Vector3 direction)
    {
        desiredRotationAngle = Vector3.Angle(transform.forward, direction);
        var crossProduct = Vector3.Cross(transform.forward, direction).y;  
        if(crossProduct < 0)
        {
            desiredRotationAngle *= -1;
        }
    }

    private void RotateAgent()
    {
        if(desiredRotationAngle > 10 || desiredRotationAngle < -10)
        {
            transform.Rotate(Vector3.up * desiredRotationAngle * rotationSpeed * Time.deltaTime);
        }
    }
}
