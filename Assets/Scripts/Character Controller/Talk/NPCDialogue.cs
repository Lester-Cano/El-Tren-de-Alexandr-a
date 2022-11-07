using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    private DialogueManager dialogueManager;

    private SFXManager SFX;
    [SerializeField] AudioClip TalkClip;

    public NPCDialogueSection currentDialogue;

    private void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Start() {
        SFX = FindObjectOfType<SFXManager>();
    }

    public void OnTalkNPC() {
        SFX.SFXSource.PlayOneShot(TalkClip);
    }
}