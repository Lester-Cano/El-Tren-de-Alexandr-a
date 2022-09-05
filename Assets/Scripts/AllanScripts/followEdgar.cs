using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followEdgar : MonoBehaviour
{
    // Start is called before the first frame updat
    [SerializeField] Transform edgar;
    NavMeshAgent nav;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(edgar.position);
    }
}
