using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Talk : MonoBehaviour
{
    //Mechanic area

    NPCDialogue dialogue;
    private int count = 0;

    //Input area
    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interaction;

    CharacterMechanics characterMechanics;
    ThirdPersonController controller;

    //TMP area

    public GameObject textContainer;
    public TMP_Text text, nameText;
    public GameObject canvas;

    private void Awake()
    {
        playerActionsAssets = new ThirdPersonActionsAssets();
        characterMechanics = GetComponent<CharacterMechanics>();
        controller = GetComponent<ThirdPersonController>();
    }

    private void Start()
    {
        OnDisable();
    }

    private void OnEnable()
    {
        interaction = playerActionsAssets.Player.Interact;
        playerActionsAssets.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionsAssets.Player.Disable();
    }

    public void TalkToNPC(GameObject target)
    {
        canvas.SetActive(true);

        dialogue = target.GetComponent<NPCDialogue>();

        if(dialogue != null)
        {
            nameText.text = dialogue.names[0];
            text.text = dialogue.dialogues[0];
        }
        else
        {
            StopTalking();
        }
    }

    public void StopTalking()
    {
        canvas.SetActive(false);
        text.text = null;
        count = 0;
    }

    public void NextText()
    {
        if (dialogue != null)
        {
            count++;
            if (count < dialogue.dialogues.Length)
            {
                nameText.text = dialogue.names[count];
                text.text = dialogue.dialogues[count];
            }
            else
            {
                StopTalking();
            }
        }
        else if(dialogue == null)
        {
            StopTalking();
        }
    }
}
