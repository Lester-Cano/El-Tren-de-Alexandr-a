using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    private SFXManager SFX;
    [SerializeField] AudioClip TalkClip;

    [SerializeField] private List<NPCDialogueSection> dialoguesList;
    [SerializeField] public NPCDialogueSection currentDialogue;

    public DialogueManager dialogueManager;

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
        Debug.Log(phase);
        Debug.Log(dialoguesList.Count);
        currentDialogue = dialoguesList[phase];
        Debug.Log("Updated CurrentDialogue");
    }
}