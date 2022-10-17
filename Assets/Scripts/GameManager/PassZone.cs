using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PassZone : MonoBehaviour
{
    [SerializeField] private GameObject pos;
    private GameObject objectToMove;
    [SerializeField] Vector3 offsetPostion = new Vector3 (0,0,3);
    // transition variables
    [SerializeField] Material transitionMaterial;
    [SerializeField] AudioSource SFX;
    [SerializeField] AudioClip TransitionSFX;
    [SerializeField] private Ease ease;
    float transitionValue;
    Sequence tranSequence;
    private void Start()
    {
        ease = Ease.InOutSine;
        transitionMaterial = Resources.Load<Material>("Transition_material");
        transitionMaterial.SetFloat("_transitionAmount", 0);
        tranSequence = DOTween.Sequence();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !tranSequence.IsPlaying())
        {
            objectToMove = other.gameObject;
            Invoke("StartCorrutineDelay", 1.5f);
            SFX.PlayOneShot(TransitionSFX);
            tranSequence.Append(transitionMaterial.DOFloat(1f, "_transitionAmount", 1.5f).SetEase(ease));
            tranSequence.Append(transitionMaterial.DOFloat(0f, "_transitionAmount", 1.5f).SetEase(ease).SetDelay(2));
        }
    }

    private IEnumerator Teleport()
    {
        if (objectToMove != null)
        {
            pos.SetActive(false);
            objectToMove.transform.position = pos.transform.position+offsetPostion;
            yield return new WaitForSeconds(2f);
            pos.SetActive(true);
        }
    }
    private void StartCorrutineDelay()
    {
        StartCoroutine(Teleport());
    }
}
