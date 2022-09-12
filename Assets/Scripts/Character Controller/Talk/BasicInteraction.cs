using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class BasicInteraction : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI iText;
    [SerializeField] GameObject ePopUp;
    public ThirdPersonActionsAssets playerControls;
    private InputAction talk;

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
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5.0f) && hit.transform.tag == "Allan")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
            iText.text = "Presiona 'E' para hablar"; talk.Enable();
            if (talk.enabled && talk.IsPressed())
            {
                ePopUp.SetActive(true);
            }
        }
        else
        {
            iText.text = "";
            talk.Disable();
            ePopUp.SetActive(false);
        }
        
    }

    public void OnButtonBack() 
    {
        ePopUp.SetActive(false); talk.Disable();
    }
}
