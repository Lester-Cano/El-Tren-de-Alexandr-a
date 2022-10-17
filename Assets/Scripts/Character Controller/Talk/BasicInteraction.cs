using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class BasicInteraction : MonoBehaviour
{
    [SerializeField] GameObject ePopUp;
    public ThirdPersonActionsAssets playerControls;
    private InputAction talk;

    [SerializeField] HUDManager hUDManager;

    //Canva

    public GameObject interactButton;

    private void Awake() 
    {
        playerControls = new ThirdPersonActionsAssets();  
        ePopUp.SetActive(false);
        interactButton.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable() 
    {
        talk = playerControls.Player.Interact;
    }

    public void OnButtonBack() 
    {
        ePopUp.SetActive(false); talk.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            talk.Enable();

            Cursor.lockState = CursorLockMode.None;
            interactButton.gameObject.SetActive(true);

            //hUDManager.textFadein();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            talk.Disable();

            Cursor.lockState = CursorLockMode.Locked;
            interactButton.gameObject.SetActive(false);

            ePopUp.SetActive(false);

            //hUDManager.textFadeout();
        }
    }

    public void TalkToAllan()
    {
        if (talk.enabled)
        {
            ePopUp.SetActive(true);
        }
    }
}
