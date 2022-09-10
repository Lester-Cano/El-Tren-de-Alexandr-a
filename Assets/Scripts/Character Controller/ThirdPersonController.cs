using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    //Input area
    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction move;

    //movement area
    private Rigidbody rb;
    [SerializeField] private float movementForce = 1f;
    [SerializeField] private float maxSpeed = 5f;

    private Vector3 forceDirection = Vector3.zero;

    [SerializeField] private Camera playerCamera;

    //Events to trigger the minimap tween

    public delegate void OnNotmoving(bool state);
    public  event OnNotmoving onNotmoving;

    //variable to count the time when the player is not moving

    float tweenTimer = 0;
    [SerializeField] public float tweenLimit;
    bool isFadded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerActionsAssets = new ThirdPersonActionsAssets();
    }

    public void OnEnable()
    {
        move = playerActionsAssets.Player.Move;
        playerActionsAssets.Player.Move.Enable();
    }

    public void OnDisable()
    {
        playerActionsAssets.Player.Move.Disable();
    }

    private void FixedUpdate()
    {
        // check if the persons is moving to fade the minimap

        if (move.ReadValue<Vector2>().x == 0 && move.ReadValue<Vector2>().y == 0)
        {
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
        else if(move.ReadValue<Vector2>().x != 0 && move.ReadValue<Vector2>().y != 0)
        {
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

        forceDirection += move.ReadValue<Vector2>().x * Vector3.right * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * Vector3.forward * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if(rb.velocity.y < 0f)
        {
            rb.velocity += Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        }

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;

        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;
        }

        LookAt();

    }

    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.25f, Vector3.down);
        
        if(Physics.Raycast(ray,out RaycastHit hit,0.3f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
