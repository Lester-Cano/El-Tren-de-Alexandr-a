using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using MoreMountains.Feedbacks;

public class ObjectPickUp : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider bcoll;
    MMF_Player MMF_Player;
    private void Awake()
    {
        MMF_Player = GetComponent<MMF_Player>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && Time.realtimeSinceStartup >=5)
        {
            Debug.Log("tal");
            MMF_Player.PlayFeedbacks();
        }
    }
}
