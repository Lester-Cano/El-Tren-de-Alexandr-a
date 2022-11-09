using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followEdgar : MonoBehaviour
{
    Transform myTransform;
    private Vector3 distanceBetween;
    [SerializeField] float distanceForTp;
    private Transform edgar, telePos;
    NavMeshAgent nav;

    private void Awake()
    {
        edgar = GameObject.FindGameObjectWithTag("Player").transform;
        telePos = GameObject.FindGameObjectWithTag("Respawn").transform;
        nav = GetComponent<NavMeshAgent>();
        myTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        nav.SetDestination(edgar.position);
        distanceBetween = edgar.position - myTransform.position;
      
    
        if (distanceBetween.magnitude > distanceForTp || distanceBetween.magnitude < -distanceForTp)
        {
            tpToEdgar();
        }
    }

    private void tpToEdgar()
    {
        Debug.Log("Teleporting");

        myTransform.position = telePos.position;
        nav.Warp(telePos.position);
    }
}
