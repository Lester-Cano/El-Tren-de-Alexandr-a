using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Talk : MonoBehaviour
{
    //Mechanic area

    [SerializeField] public CinemachineVirtualCamera gameCam;
    NPCDialogue dialogue;
    private int count = 0;

    //Input area
    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interaction;

    CharacterMechanics characterMechanics;
    ThirdPersonController controller;

    //TMP area

    public GameObject textContainer;
    public TMP_Text text;
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
    }

    public void NextText()
    {
        if (dialogue != null)
        {
            count++;
            if (count < dialogue.dialogues.Length)
            {
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
