using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllanAnimatorController : MonoBehaviour
{
    NavMeshAgent Agent;
    [SerializeField] Animator animator;
    private void Awake()
    {
        Agent = gameObject.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Agent.velocity.magnitude <= 0.5)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
    }
}
