using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class FeedbackTalk : MonoBehaviour
{   
    [SerializeField] RectTransform verticalArrow;
    [SerializeField] private float arrowHeight;
    [SerializeField] private Image illustrationImage;
    Vector2 InicialPosition;
    private void Start()
    {
        InicialPosition = new Vector2(verticalArrow.anchoredPosition.x, verticalArrow.anchoredPosition.y);
    }
    public void TweenArrow()
    {
        verticalArrow.anchoredPosition = InicialPosition;
        verticalArrow.gameObject.SetActive(true);
        verticalArrow.DOAnchorPos(InicialPosition+ new Vector2(0, arrowHeight), 0.2f, false).SetLoops(-1,LoopType.Yoyo);
    }
    public void StopTween()
    {
        verticalArrow.gameObject.SetActive(false);
        verticalArrow.DOPause();
    }
    public void fadeImage( Sprite nextSprite)
    {
        illustrationImage.DOFade(0, 0.25f);
        illustrationImage.sprite = nextSprite;
        illustrationImage.DOFade(1, 0.25f).SetDelay(0.75f);
    }
}
