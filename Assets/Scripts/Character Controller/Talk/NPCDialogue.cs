using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    //public string[] names;
    //public string[] dialogues;
    //public List<NPCImage> NPCImages;
    private SFXManager SFX;
    [SerializeField] AudioClip TalkClip;

    public List<NPCDialogueSection> nPCDialogueSections;
    public NPCDialogueSection currentDialogue;

    private DialogueManager dialogueManager;

    private void Awake()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Start() {
        SFX = FindObjectOfType<SFXManager>();
    }

    private void OnEnable()
    {
        dialogueManager.OnSetPhase += SetCurrentDialogue;
    }

    private void OnDisable()
    {
        dialogueManager.OnSetPhase -= SetCurrentDialogue;
    }

    public void OnTalkNPC() {
        SFX.SFXSource.PlayOneShot(TalkClip);
    }

    public void SetCurrentDialogue(int phase)
    {
        currentDialogue = nPCDialogueSections[phase];
    }
}