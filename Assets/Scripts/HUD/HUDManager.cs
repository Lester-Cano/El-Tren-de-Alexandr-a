using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.Feedbacks;
public class HUDManager : MonoBehaviour
{
    public float fadeTime = 0.5f;
    public CanvasGroup canvasGroup;
    public CanvasGroup canvasText;
    public RectTransform rect;
    public RectTransform rectText;
    public RectTransform rectImage;
    public bool fadedOut;
    public MovementController movController;
    [SerializeField] MMF_Player TextFeedbackPlayer;
    [SerializeField] MMF_Player MapFeedbackPlayer;

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
        if (state) Panelfadeout();
        else PanelfadeIn();
    }

    private void PanelfadeIn ()
    {
        canvasGroup.alpha = 0;
        rect.transform.localPosition = new Vector3(0, -100f, 0);
        rect.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.InOutSine);
        canvasGroup.DOFade(1, fadeTime);
        MapFeedbackPlayer.PlayFeedbacks();



    }

    public void Panelfadeout()
    {
        if (rect.transform.localPosition == new Vector3(0, 0, 0))
        {
            canvasGroup.alpha = 1;
            MapFeedbackPlayer.PlayFeedbacks();
            rect.transform.localPosition = new Vector3(0, 0, 0);
            rect.DOAnchorPos(new Vector2(0, -1000), fadeTime, false).SetEase(Ease.InSine);

            canvasGroup.DOFade(0, fadeTime);
        }
    }

    public void textFadein()
    {
        // Grab a free Sequence to use
        Sequence mySequence = DOTween.Sequence();
        // Add a movement tween at the beginning
        canvasText.alpha = 0;
        rectText.transform.localPosition = new Vector3(0, -100f, 0);
        canvasText.DOFade(1, fadeTime);
        rectText.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.InOutSine);

        // Add a rotation tween as soon as the previous one is finished
        mySequence.Append(transform.DORotate(new Vector3(0, 180, 0), 1));
        // Delay the whole Sequence by 1 second
        mySequence.PrependInterval(1);
        // Insert a scale tween for the whole duration of the Sequence
            TextFeedbackPlayer.PlayFeedbacks();
        
    }
    public void textFadeout()
    {
        TextFeedbackPlayer.StopFeedbacks();
        canvasText.alpha = 1;
        rectText.transform.localPosition = new Vector3(0, 0, 0);
        rectText.DOAnchorPos(new Vector2(0, -1000), fadeTime, false).SetEase(Ease.InSine);
        canvasText.DOFade(0, fadeTime);
    }
    
}
