using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using MoreMountains.Feedbacks;

public class PlayerPickUp : MonoBehaviour
{
    //Mechanic area

    public ObjectPickUp objectPickUp;
    public Transform objectpickupContainer;


    public float dropForwardForce, dropUpwardForce;
    [SerializeField] MMF_Player mmPlayer;
    public bool onHand;
    public bool HandsFull;

    //Input area

    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interact;
    ThirdPersonController controller;

    private void Awake()
    {
        playerActionsAssets = new ThirdPersonActionsAssets();
        controller = GetComponent<ThirdPersonController>();
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

    private void Update()
    {
        if (onHand && playerActionsAssets.Player.ThrowObject.triggered)
        {
            Drop();
        }
    }

    public void PickUp(GameObject target)
    {
        onHand = true;
        HandsFull = true;

        objectPickUp = target.GetComponent<ObjectPickUp>();
        mmPlayer.PlayFeedbacks();
        objectPickUp.transform.SetParent(objectpickupContainer);
        objectPickUp.transform.localPosition = Vector3.zero;
        objectPickUp.transform.rotation = Quaternion.Euler(Vector3.zero);

        objectPickUp.rb.isKinematic = true;
        objectPickUp.bcoll.isTrigger = true;
        objectPickUp.enabled = true;
    }

    public void Drop()
    {
        onHand = false;
        HandsFull = false;

        objectPickUp.transform.SetParent(null);

        objectPickUp.bcoll.isTrigger = false;
        objectPickUp.rb.isKinematic = false;
        objectPickUp.enabled = false;

        objectPickUp.rb.velocity = transform.GetComponent<Rigidbody>().velocity;
        objectPickUp.rb.AddForce(transform.forward * dropForwardForce, ForceMode.Impulse);
        objectPickUp.rb.AddForce(transform.up * dropUpwardForce, ForceMode.Impulse);

        objectPickUp = null;
    }
}
