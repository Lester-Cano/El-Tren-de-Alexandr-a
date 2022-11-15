using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    //Mechanic area

    NPCDialogue dialogue;
    List<NPCImage> nPCImages;
    int[,] imagePlacements; 
    private int count = 0;
    private int imageCounter = 0;
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
        FillArrays(dialogue);
        dialogue.OnTalkNPC();

        if (dialogue != null)
        {
            nameText.text = dialogue.currentDialogue.names[0];
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
        imageCounter = 0;
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
            if (count < dialogue.currentDialogue.dialogues.Length)
            {
                nameText.text = dialogue.currentDialogue.names[count];
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

    private void FillArrays(NPCDialogue nPCDialogue)
    {
        nPCImages = nPCDialogue.currentDialogue.NPCImages;
        imagePlacements = new int[nPCImages.Count, 2];
        for (int i = 0; i < nPCImages.Count; i++)
        {
            imagePlacements[i, 0] = nPCImages[i].Dialogue;
            imagePlacements[i, 1] = nPCImages[i].letterPlacement;
        }
    }

    IEnumerator WriteText()
    {
        feedbackTalk.StopTween();
        writing = true;
        for (int i = 0; i < dialogue.currentDialogue.dialogues[count].Length; i++)
        {
            if (imagePlacements[count, 1] == i)
            {
                feedbackTalk.fadeImage(nPCImages[imageCounter].illustrarion);
                imageCounter++;
            }
            currentText = dialogue.currentDialogue.dialogues[count].Substring(0, i);
            text.text = currentText;
            if(i+1== dialogue.currentDialogue.dialogues[count].Length)
            {
                writing = false;
                feedbackTalk.TweenArrow();
            }
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
