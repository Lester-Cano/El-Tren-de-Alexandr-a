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
    private SFXManager SFX;
    [SerializeField] AudioClip[] TalkClip;
    private PlayerPickUp playerPickUp;
    public bool interactingAllan;
    //Canva

    public GameObject interactButton;

    private CharacterMechanics characterMechanics;

    private void Awake() 
    {
        playerControls = new ThirdPersonActionsAssets();  
        ePopUp.SetActive(false);
        SFX = FindObjectOfType<SFXManager>();

        playerPickUp = GameObject.Find("Edgar NIS").GetComponent<PlayerPickUp>();
        characterMechanics = GameObject.Find("Edgar NIS").GetComponent<CharacterMechanics>();
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
        if (other.CompareTag("Player") && playerPickUp.onHand == false && characterMechanics.isInteracting == false)
        {
            talk.Enable();
            interactingAllan = true;
            hUDManager.TalkTextFadeIn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            talk.Disable();
            interactingAllan = false;
            ePopUp.SetActive(false);

            hUDManager.TalkTextFadeOut();
        }
    }

    public void TalkToAllan()
    {
        if (talk.enabled)
        {
            ePopUp.SetActive(true); OnTalkAllan();
        }
    }
    public void OnTalkAllan(){
        SFX.SFXSource.PlayOneShot(TalkClip[Random.Range(0,2)]);
    }
}
