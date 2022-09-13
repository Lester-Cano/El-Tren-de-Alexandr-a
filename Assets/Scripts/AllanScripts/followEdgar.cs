using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followEdgar : MonoBehaviour
{
    // Start is called before the first frame updat
    Transform myTransform;
    private Vector3 distanceBetween;
    [SerializeField] float distanceForTp;
    [SerializeField] Transform edgar,telePos;
    NavMeshAgent nav;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(edgar.position);
        distanceBetween = edgar.position - myTransform.position;
        if (distanceBetween.magnitude > distanceForTp)
        {
            tpToEdgar();
        }
    }

    public void tpToEdgar()
    {
        myTransform.position = telePos.position + Vector3.up;
    }
}
