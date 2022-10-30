using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonsAudio : MonoBehaviour
{
    [SerializeField] AudioSource AudioSFX;
    [SerializeField] AudioClip buttonMain, buttonSecond;

    public void OnMainButtons() {
        AudioSFX.PlayOneShot(buttonMain);
    }
    public void OnSecondaryButtons() {
        AudioSFX.PlayOneShot(buttonSecond);
    }
    
}
