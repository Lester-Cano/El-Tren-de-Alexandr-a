using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject controlsP, mainMenuP, optionsP, MPosition, RPosition, LPosition;
    [SerializeField] AudioSource AudioSFX;
    [SerializeField] AudioClip buttonMain, buttonSecond;

    private void Start() {
        DOTween.Init();
    }
    public void OnControlsButton() {
        controlsP.transform.DOMove(MPosition.gameObject.transform.position, 0.5f);
        mainMenuP.transform.DOMove(LPosition.gameObject.transform.position, 0.5f);
        AudioSFX.PlayOneShot(buttonMain);
    }
    public void OnOptionsButton() {
        optionsP.transform.DOMove(MPosition.gameObject.transform.position, 0.5f);
        mainMenuP.transform.DOMove(RPosition.gameObject.transform.position, 0.5f);
        AudioSFX.PlayOneShot(buttonMain);
    }

    public void OnReturnButton() {
        mainMenuP.transform.DOMove(MPosition.gameObject.transform.position, 0.5f);
        controlsP.transform.DOMove(RPosition.gameObject.transform.position, 0.5f);
        optionsP.transform.DOMove(LPosition.gameObject.transform.position, 0.5f);
        AudioSFX.PlayOneShot(buttonSecond);
    }
    public void OnPlayButton() {
        SceneManager.LoadScene("Cinematica");
    }

    public void OnExitButton() {
        Debug.Log("Adiós"); Application.Quit();
    }
}
