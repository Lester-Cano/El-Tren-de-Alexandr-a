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

    //Letter Writer Area

    [SerializeField] private float textSpeed;
    private string currentText ="";
    private bool writing;
    private float initialTextSpeed;
    [SerializeField] FeedbackTalk feedbackTalk;
    private void Awake()
    {
        playerActionsAssets = new ThirdPersonActionsAssets();
        characterMechanics = GetComponent<CharacterMechanics>();
        controller = GetComponent<ThirdPersonController>();
    }

    private void Start()
    {
        OnDisable();
        initialTextSpeed = textSpeed;
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
        dialogue.OnTalkNPC();

        if (dialogue != null  )
        {
            nameText.text = dialogue.names[0];
            if(!writing) StartCoroutine("WriteText");

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
        if (writing)
        {
            textSpeed = 0;
        }
        else if (dialogue != null )
        {
            feedbackTalk.StopTween();
            textSpeed = initialTextSpeed;
            count++;
            if (count < dialogue.dialogues.Length)
            {
                nameText.text = dialogue.names[count];
                writing = true;
               StartCoroutine("WriteText");
            }
            else
            {
                StopTalking();
            }
        }
        else if (dialogue == null)
        {
            StopTalking();
        }
    }
    IEnumerator WriteText()
    {
        feedbackTalk.StopTween();
        writing = true;
        for (int i = 0; i < dialogue.dialogues[count].Length; i++)
        {
            currentText = dialogue.dialogues[count].Substring(0, i);
            text.text = currentText;
            if(i+1== dialogue.dialogues[count].Length)
            {
                writing = false;
                feedbackTalk.TweenArrow();
            }
            yield return new WaitForSeconds(textSpeed);

        }
    }
}
