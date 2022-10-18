using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.Feedbacks;
public class HUDManager : MonoBehaviour
{
    public float fadeTime = 0.5f;
    //Interact Variables
    public RectTransform interactRect;
    public CanvasGroup interactCanvasGroup;
    [SerializeField] MMF_Player InteractFeedBackPlayer;
    //MiniMap Variables
    public CanvasGroup miniMapGroup;
    public RectTransform miniMapRect;
    [SerializeField] MMF_Player MapFeedbackPlayer;
    //Talk Mechanic Variables
    public RectTransform talkRect;
    public CanvasGroup talkCanvasGroup;
    [SerializeField] MMF_Player TalkFeedBackPlayer;

    public bool fadedOut;
    public MovementController movController;



    private void OnEnable()
    {
        movController.onNotmoving += PanelFade;
    }

    private void OnDisable()
    {
        movController.onNotmoving -= PanelFade;
    }

    private void PanelFade (bool state)
    {
        if (state) MiniMapFadeout();
        else MiniMapFadeIn();
    }

    private void MiniMapFadeIn ()
    {
        miniMapGroup.alpha = 0;
        miniMapRect.transform.localPosition = new Vector3(0, -100f, 0);
        miniMapRect.DOAnchorPos(new Vector2(0f, 0f), 1, false).SetEase(Ease.InOutSine);
        miniMapGroup.DOFade(1, 1);
        MapFeedbackPlayer.PlayFeedbacks();
    }
    public void MiniMapFadeout()
    {
        if (miniMapRect.transform.localPosition == new Vector3(0, 0, 0))
        {
            miniMapGroup.alpha = 1;
            MapFeedbackPlayer.PlayFeedbacks();
            miniMapRect.transform.localPosition = new Vector3(0, 0, 0);
            miniMapRect.DOAnchorPos(new Vector2(0, -1000), 1, false).SetEase(Ease.InSine);

            miniMapGroup.DOFade(0, 1);
        }
    }

    public void InteractTextFadeIn()
    {
        interactCanvasGroup.DOFade(1, fadeTime);
        interactRect.DOAnchorPos(new Vector2(0, -430f), fadeTime, false).SetEase(Ease.InOutSine);
        InteractFeedBackPlayer.PlayFeedbacks();
        Debug.Log("a");
    }
    public void InteractTextFadeOut()
    {
        InteractFeedBackPlayer.StopFeedbacks();
        interactRect.DOAnchorPos(new Vector2(0, -1000), fadeTime, false).SetEase(Ease.InSine);
        interactCanvasGroup.DOFade(0, fadeTime);
    }
    public void TalkTextFadeOut()
    {
        TalkFeedBackPlayer.StopFeedbacks();
        talkRect.DOAnchorPos(new Vector2(0, -1000), fadeTime, false).SetEase(Ease.InSine);
        talkCanvasGroup.DOFade(0, fadeTime);
    }
    public void TalkTextFadeIn()
    {
        talkCanvasGroup.DOFade(1, fadeTime);
        talkRect.DOAnchorPos(new Vector2(0f, -350f), fadeTime, false).SetEase(Ease.InOutSine);
        TalkFeedBackPlayer.PlayFeedbacks();
    }
    
}