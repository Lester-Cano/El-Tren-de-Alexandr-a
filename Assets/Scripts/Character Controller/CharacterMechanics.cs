using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class CharacterMechanics : MonoBehaviour
{

    //Hud area
    private HUDManager hUDManager;

    //Mechanics area
    //[HideInInspector]
    public bool isInteracting, analizable, pickable, talkable;

    //Mechanics scripts
    private Analize analize;
    private Talk talk;
    private PlayerPickUp playerPickUp;

    private CharacterController characterController;
    private BasicInteraction basic;
    //Input area
    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interact;

    //Private for Analize Mechanic
    public GameObject objectToInteractWith;

    //Inventory Area

    public InventoryObject inventory;
    public GameObject inventoryCanva;

    //Canva

    public GameObject interactButton;

    public Item itemToStore;

    private void Awake()
    {
        playerActionsAssets = new ThirdPersonActionsAssets();
        analize = GetComponentInParent<Analize>();
        talk = GetComponentInParent<Talk>();
        playerPickUp = GetComponentInParent<PlayerPickUp>();

        hUDManager = FindObjectOfType<HUDManager>();
        basic = FindObjectOfType<BasicInteraction>();
        characterController = GetComponentInParent<CharacterController>();

        Cursor.lockState = CursorLockMode.None;
    }

    private void Start()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Analizable") && !basic.interactingAllan)
        {
            isInteracting = true;
            analizable = true;
            objectToInteractWith = other.gameObject;
            itemToStore = objectToInteractWith.GetComponent<Item>();

            hUDManager.InteractTextFadeIn();
        }
        else if (other.gameObject.CompareTag("Pickable") && !basic.interactingAllan)
        {
            isInteracting = true;
            pickable = true;

            objectToInteractWith = other.gameObject;

            hUDManager.InteractTextFadeIn();
        }
        else if (other.gameObject.CompareTag("Talkable") && !basic.interactingAllan)
        {
            isInteracting = true;
            talkable = true;

            objectToInteractWith = other.gameObject;

            hUDManager.InteractTextFadeIn();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        isInteracting = false;
        analizable = false;
        pickable = false;
        talkable = false;

        if(other.gameObject.CompareTag("Analizable")|| other.gameObject.CompareTag("Pickable")|| other.gameObject.CompareTag("Talkable"))
        {
            hUDManager.InteractTextFadeOut();
        }
        if (other.gameObject.CompareTag("Talkable")) 
        {
            talk.StopTalking();
        }

        objectToInteractWith = null;
    }

    private void PickUpObject()
    {
        if (itemToStore)
        {
            inventory.AddItem(itemToStore.item, 1);
            Destroy(objectToInteractWith);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }

    public void SendToMechanic()
    {
        if (isInteracting)
        {
            hUDManager.InteractTextFadeOut();
            if (analizable)
            {
                hUDManager.InteractTextFadeOut();
                analize.GoToAnalize(objectToInteractWith);

                PickUpObject();

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
}
