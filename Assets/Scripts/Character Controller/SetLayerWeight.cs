using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLayerWeight : MonoBehaviour
{
    Animator animator;
    PlayerPickUp playerPick;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerPick = GetComponentInParent<PlayerPickUp>();
    }
    public void SetAnimationSpeed()
    {
        animator.SetFloat("pickSpeed", 0);
    }
    public void SetWeight()
    {
        animator.SetLayerWeight(animator.GetLayerIndex("throw"), 0);
        animator.SetBool("throw", false);
        animator.SetFloat("pickSpeed", 0);
    }
    public void TriggerThrow()
    {
        playerPick.Drop();
    }
}
