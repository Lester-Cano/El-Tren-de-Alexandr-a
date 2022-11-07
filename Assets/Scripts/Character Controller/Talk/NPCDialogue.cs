using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    private SFXManager SFX;
    [SerializeField] AudioClip TalkClip;

    public NPCDialogueSection[] dialoguesList;
    public NPCDialogueSection currentDialogue;

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
        Debug.Log(phase + "Esta es la fase enviada");
        Debug.Log(dialoguesList.Length + "Esta es la longitud del arreglo");
        currentDialogue = dialoguesList[phase];
        Debug.Log("Updated CurrentDialogue");
    }
}