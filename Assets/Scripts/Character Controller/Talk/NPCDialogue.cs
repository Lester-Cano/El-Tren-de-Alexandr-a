using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public string[] names;
    public string[] dialogues;
    public List<NPCImage> NPCImages;
    private SFXManager SFX;
    [SerializeField] AudioClip TalkClip;

    private void Start() {
        SFX = FindObjectOfType<SFXManager>();
    }

    public void OnTalkNPC() {
        SFX.SFXSource.PlayOneShot(TalkClip);
    }


}
