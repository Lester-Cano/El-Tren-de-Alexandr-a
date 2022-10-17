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

    private void Awake() {
        playerControls = new ThirdPersonActionsAssets();  
        ePopUp.SetActive(false);
    }

    private void OnEnable() {
        talk = playerControls.Player.Interact;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 20.0f) && hit.transform.tag == "Allan")
        {
            Debug.Log("Hit Allan");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
            talk.Enable();
            //hUDManager.textFadein();
            if (talk.enabled && talk.IsPressed())
            {
                Cursor.lockState = CursorLockMode.None;
                ePopUp.SetActive(true);
            }
        }
        else
        {
            //hUDManager.textFadeout();
            talk.Disable();
            ePopUp.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }

    public void OnButtonBack() 
    {
        ePopUp.SetActive(false); talk.Disable();
    }
}
