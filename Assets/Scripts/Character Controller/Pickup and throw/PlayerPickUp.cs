using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickUp : MonoBehaviour
{
    private ThirdPersonActionsAssets playerActionsAssets;
    public InputAction interact;
    public InputAction throwObject;
    public ObjectPickUp objectPickUp;
    public Rigidbody rb;
    public BoxCollider bcoll;
    public Transform player, objectpickupContainer, mainCamera;

    public float dropForwardForce, dropUpwardForce;

    public bool onHand;
    public bool HandsFull;

    private void Awake()
    {
        playerActionsAssets = new ThirdPersonActionsAssets();
    }
   

    private void Start()
    {
        if (!onHand)
        {
            objectPickUp.enabled = false;
            rb.isKinematic = false;
            bcoll.isTrigger = false;
        }
    }
    private void OnEnable()
    {
        interact = playerActionsAssets.Player.Interact;
        throwObject = playerActionsAssets.Player.Throw;
        playerActionsAssets.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionsAssets.Player.Disable();
    }

    private void Update()
    {
        if (!onHand && interact.triggered && !HandsFull)
        {
            PickUp();
        }

        if ( throwObject.triggered && onHand)
        {
            Drop();
        }
    }

    public void PickUp()
    {
        onHand = true;
        HandsFull = true;

        transform.SetParent(objectpickupContainer);
        transform.localPosition = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);

        rb.isKinematic = true;
        bcoll.isTrigger = true;

        objectPickUp.enabled = true;


    }

    public void Drop()
    {
        onHand = false;
        HandsFull = false;

        transform.SetParent(null);
        rb.isKinematic = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        rb.AddForce(player.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(player.up * dropUpwardForce, ForceMode.Impulse);

       
        bcoll.isTrigger = false;

        objectPickUp.enabled = false;
    }
}
