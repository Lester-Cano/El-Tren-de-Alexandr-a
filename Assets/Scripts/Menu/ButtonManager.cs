using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject creditsP, mainMenuP, optionsP, controlsP, MPosition, RPosition, LPosition, UpPosition, DPosition;
    [SerializeField] AudioSource AudioSFX;
    [SerializeField] AudioClip buttonMain, buttonSecond;

    private void Start() {
        DOTween.Init();
    }
    public void OnCreditsButton() {
        creditsP.transform.DOMove(MPosition.gameObject.transform.position, 0.5f);
        mainMenuP.transform.DOMove(RPosition.gameObject.transform.position, 0.5f);
        AudioSFX.PlayOneShot(buttonMain);
    }
    public void OnOptionsButton() {
        optionsP.transform.DOMove(MPosition.gameObject.transform.position, 0.5f);
        mainMenuP.transform.DOMove(LPosition.gameObject.transform.position, 0.5f);
        AudioSFX.PlayOneShot(buttonMain);
    }

    public void OnReturnButton() {
        mainMenuP.transform.DOMove(MPosition.gameObject.transform.position, 0.5f);
        creditsP.transform.DOMove(LPosition.gameObject.transform.position, 0.5f);
        optionsP.transform.DOMove(RPosition.gameObject.transform.position, 0.5f);
        controlsP.transform.DOMove(UpPosition.gameObject.transform.position, 0.5f);
        AudioSFX.PlayOneShot(buttonSecond);
    }
    public void OnCrontrolButton() {
        controlsP.transform.DOMove(MPosition.gameObject.transform.position, 0.5f);
        mainMenuP.transform.DOMove(DPosition.gameObject.transform.position, 0.5f);
        AudioSFX.PlayOneShot(buttonMain);
    }
    public void OnPlayButton() {
        SceneManager.LoadScene("Cinematica");
    }

    public void OnExitButton() {
        Debug.Log("Adiós"); Application.Quit();
    }
}
