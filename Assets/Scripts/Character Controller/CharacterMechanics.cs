using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMechanics : MonoBehaviour
{
    //Mechanics area
    [SerializeField] private CapsuleCollider charCollider;
    private bool isInteracting, analizable, pickable, talkable;

    //Mechanics scripts
    private Analize analize;
    private Talk talk;

    //Input area
    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interact;

    //Private for Analize Mechanic
    private GameObject objectToAnalize;

    private void Awake()
    {
        charCollider = GetComponentInParent<CapsuleCollider>();
        playerActionsAssets = new ThirdPersonActionsAssets();
        analize = GetComponentInParent<Analize>();
        talk = GetComponent<Talk>();
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
                analize.GoToAnalize(objectToAnalize);

                StartCoroutine(analize.AllanBothering());

            }
            else if (pickable)
            {

            }
            else if (talkable)
            {
                talk.TalkToNPC(objectToAnalize);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Analizable"))
        {
            isInteracting = true;
            analizable = true;

            objectToAnalize = other.gameObject;
        }
        else if (other.gameObject.CompareTag("Pickable"))
        {
            isInteracting = true;
            pickable = true;
        }
        else if (other.gameObject.CompareTag("Talkable"))
        {
            isInteracting = true;
            talkable = true;

            objectToAnalize = other.gameObject;
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
