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
    public int counter;

    private void Awake() {
        playerControls = new ThirdPersonActionsAssets();  
        ePopUp.SetActive(false);
        interactButton.SetActive(false);
    }

    private void OnEnable() {
        talk = playerControls.Player.Interact;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 20.0f) && hit.transform.tag == "Allan")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
            talk.Enable();

            Cursor.lockState = CursorLockMode.None;
            interactButton.gameObject.SetActive(true);

            counter = 0;

            //hUDManager.textFadein();
        }
        else
        {
            //hUDManager.textFadeout();
            talk.Disable();
            ePopUp.SetActive(false);
            interactButton.gameObject.SetActive(false);

            if(counter == 0)
            {
                Cursor.lockState = CursorLockMode.Locked;
                counter++;
            }
        }
        
    }

    public void OnButtonBack() 
    {
        ePopUp.SetActive(false); talk.Disable();
    }

    public void TalkToAllan()
    {
        if (talk.enabled)
        {
            ePopUp.SetActive(true);
        }
    }
}
