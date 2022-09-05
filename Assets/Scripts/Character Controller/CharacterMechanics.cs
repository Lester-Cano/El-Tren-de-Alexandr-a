using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class CharacterMechanics : MonoBehaviour
{
    //Mechanics area
    public bool isInteracting, analizable, pickable, talkable;

    //Mechanics scripts
    private Analize analize;
    private Talk talk;
    private PlayerPickUp playerPickUp;

    //Input area
    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interact;

    //Private for Analize Mechanic
    private GameObject objectToInteractWith;

    private void Awake()
    {
        playerActionsAssets = new ThirdPersonActionsAssets();
        analize = GetComponentInParent<Analize>();
        talk = GetComponent<Talk>();
        playerPickUp = GetComponent<PlayerPickUp>();
    }

    public void OnEnable()
    {
        interact = playerActionsAssets.Player.Interact;
        playerActionsAssets.Player.Interact.Enable();
    }

    public void OnDisable()
    {
        playerActionsAssets.Player.Interact.Disable();
    }

    private void Update()
    {
        if (playerActionsAssets.Player.Interact.triggered && isInteracting)
        {
            if (analizable)
            {
                analize.GoToAnalize(objectToInteractWith);

                StartCoroutine(analize.AllanBothering());

            }
            else if (pickable)
            {
                if (!playerPickUp.onHand && !playerPickUp.HandsFull)
                {
                    playerPickUp.PickUp(objectToInteractWith);
                }
            }
            else if (talkable)
            {
                talk.TalkToNPC(objectToInteractWith);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Analizable"))
        {
            isInteracting = true;
            analizable = true;

            objectToInteractWith = other.gameObject;
        }
        else if (other.gameObject.CompareTag("Pickable"))
        {
            isInteracting = true;
            pickable = true;

            objectToInteractWith = other.gameObject;
        }
        else if (other.gameObject.CompareTag("Talkable"))
        {
            isInteracting = true;
            talkable = true;

            objectToInteractWith = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInteracting = false;
        analizable = false;
        pickable = false;
        talkable = false;
    }
}
