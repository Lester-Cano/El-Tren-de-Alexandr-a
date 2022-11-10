using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using MoreMountains.Feedbacks;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerPickUp : MonoBehaviour
{
    //Mechanic area

    public ObjectPickUp objectPickUp;
    public Transform objectpickupContainer;
    public Transform PickPoint;

    public float dropForwardForce, dropUpwardForce;
    [SerializeField] MMF_Player mmPlayer;
    public bool onHand;
    public bool HandsFull;

    //Input area

    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interact;
    ThirdPersonController controller;

    //Button

    private Button interactButton;

    //Animator
    [SerializeField] Animator animator;
    private void Awake()
    {
        playerActionsAssets = new ThirdPersonActionsAssets();
        controller = GetComponent<ThirdPersonController>();

        interactButton = GameObject.Find("InteractButton").GetComponent<Button>();
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
            animator.SetBool("throw", true);
            //Drop();
        }
    }

    public void PickUp(GameObject target)
    {
        onHand = true;
        HandsFull = true;
        objectPickUp = target.GetComponent<ObjectPickUp>();
        mmPlayer.PlayFeedbacks();
        objectPickUp.transform.SetParent(objectpickupContainer);
        objectPickUp.transform.TransformPoint(Vector3.zero);
        objectPickUp.transform.localPosition = PickPoint.localPosition;
        if (target.GetComponent<ColorBoxPuzzle>() != null)
        {
            target.GetComponent<ColorBoxPuzzle>().pickedUp = true;
        }
        //objectPickUp.transform.DOMove(PickPoint.position, 0.3f).SetDelay(0.1f);
        objectPickUp.transform.rotation = Quaternion.Euler(Vector3.zero);
        objectPickUp.rb.isKinematic = true;
        objectPickUp.bcoll.isTrigger = true;
        objectPickUp.enabled = true;
        //handle animation
        animator.SetLayerWeight(animator.GetLayerIndex("throw"), 1);
        animator.SetFloat("pickSpeed", 1);

        //
        interactButton.onClick.AddListener(Throw);
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
        objectPickUp.rb.AddForce(-transform.up * dropUpwardForce, ForceMode.Impulse);
        if (objectPickUp.puzzle != null)
        {
            objectPickUp.puzzle.pickedUp = false;
        }
        objectPickUp = null;

        //handle animation
        //animator.SetBool("throw",true);

        interactButton.onClick.RemoveListener(Throw);
    }

    private void Throw()
    {
        animator.SetBool("throw", true);
    }
}
