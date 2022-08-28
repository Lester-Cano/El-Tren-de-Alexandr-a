using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMechanics : MonoBehaviour
{
    //Mechanics area
    [SerializeField] private CapsuleCollider charCollider;
    private bool isInteracting;

    //Mechanics scripts
    private Analize analize;

    //Input area
    private Rigidbody rb;
    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interact;

    private void Awake()
    {
        charCollider = GetComponentInParent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        playerActionsAssets = new ThirdPersonActionsAssets();

        analize = gameObject.AddComponent<Analize>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Analizable"))
        {
            isInteracting = true;

            if (isInteracting)
            {
                Debug.Log("Analizable Object");
            }
        }
        else if (other.gameObject.CompareTag("Pickable"))
        {
            isInteracting = true;

            if (isInteracting)
            {
                Debug.Log("Pickable Object");
            }
        }
        else if (other.gameObject.CompareTag("Pushable"))
        {
            isInteracting = true;

            if (isInteracting)
            {
                Debug.Log("Pushable Object");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInteracting = false;
    }
}
