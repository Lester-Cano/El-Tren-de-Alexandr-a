using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonsAudio : MonoBehaviour
{
    [SerializeField] AudioSource AudioSFX;
    [SerializeField] AudioClip buttonMain, buttonSecond;

    public void OnMainButtonsAllan() {
        AudioSFX.PlayOneShot(buttonMain);
    }
    public void OnSecondaryButtonsAllan() {
        AudioSFX.PlayOneShot(buttonSecond);
    }
    
}
