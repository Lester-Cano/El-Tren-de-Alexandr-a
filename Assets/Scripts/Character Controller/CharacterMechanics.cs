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
    [HideInInspector]
    public bool isInteracting, analizable, pickable, talkable;

    //Mechanics scripts
    private Analize analize;
    private Talk talk;
    private PlayerPickUp playerPickUp;

    //Input area
    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interact;

    //Private for Analize Mechanic
    public GameObject objectToInteractWith;

    //Inventory Area

    public InventoryObject inventory;
    public GameObject inventoryCanva;

    private void Awake()
    {
        playerActionsAssets = new ThirdPersonActionsAssets();
        analize = GetComponentInParent<Analize>();
        talk = GetComponentInParent<Talk>();
        playerPickUp = GetComponentInParent<PlayerPickUp>();

        hUDManager = FindObjectOfType<HUDManager>();
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
            hUDManager.textFadeout();
            if (analizable)
            {
                hUDManager.Panelfadeout();
                analize.GoToAnalize(objectToInteractWith);

                StartCoroutine(PickUpObject());

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

            hUDManager.textFadein();
        }
        else if (other.gameObject.CompareTag("Pickable"))
        {
            isInteracting = true;
            pickable = true;

            objectToInteractWith = other.gameObject;

            hUDManager.textFadein();
        }
        else if (other.gameObject.CompareTag("Talkable"))
        {
            isInteracting = true;
            talkable = true;

            objectToInteractWith = other.gameObject;

            hUDManager.textFadein();
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
            hUDManager.textFadeout();
        }
        if (other.gameObject.CompareTag("Talkable")) {
            talk.StopTalking();
        }
    }

    private IEnumerator PickUpObject()
    {
        var item = objectToInteractWith.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(objectToInteractWith);

            inventoryCanva.SetActive(true);

            yield return new WaitForSeconds(2f);


            inventoryCanva.SetActive(false);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }
}
