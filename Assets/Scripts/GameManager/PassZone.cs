using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PassZone : MonoBehaviour
{
    [SerializeField] private GameObject pos,Fox;
    private GameObject objectToMove;
    // transition variables
    [SerializeField] Material transitionMaterial;
    [SerializeField] AudioSource SFX;
    [SerializeField] AudioClip TransitionSFX;
    [SerializeField] private Ease ease;
    [SerializeField] Vector3 offset;
   
    float transitionValue;
    Sequence tranSequence;

    private bool teleporting;
    private CharacterController characterController;

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
            teleporting = true;

            objectToMove = other.gameObject;
            characterController = other.GetComponent<CharacterController>();
            characterController.enabled = false;

            Invoke("StartCorrutineDelay", 1.5f);
            SFX.PlayOneShot(TransitionSFX);
            tranSequence.Append(transitionMaterial.DOFloat(1f, "_transitionAmount", 1.5f).SetEase(ease));
            tranSequence.Append(transitionMaterial.DOFloat(0f, "_transitionAmount", 1.5f).SetEase(ease).SetDelay(2));
        }
    }

    private IEnumerator Teleport()
    {
        if (objectToMove != null && teleporting && pos != null)
        {
            teleporting = false;

            objectToMove.transform.position = pos.transform.position + offset;

            characterController.enabled = true;
            characterController = null;
            Fox.SetActive(false);
            yield return new WaitForSeconds(2f);

            teleporting = true;
        }
    }
    private void StartCorrutineDelay()
    {
        StartCoroutine(Teleport());
    }
}
