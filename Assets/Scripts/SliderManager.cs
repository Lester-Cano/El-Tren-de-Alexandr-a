using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup musicMixer, generalMixer;
    
    public void SetMusicVolume(float sliderValue)
    {
        musicMixer.audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetGeneralVolume(float sliderValue)
    {
        generalMixer.audioMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }
}
