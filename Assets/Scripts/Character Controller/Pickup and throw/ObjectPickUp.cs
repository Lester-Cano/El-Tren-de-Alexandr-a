using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using MoreMountains.Feedbacks;

public class ObjectPickUp : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider bcoll;
    public ColorBoxPuzzle puzzle;
    [SerializeField] GameObject mySelf;
    MMF_Player MMF_Player;
    private void Awake()
    {
        MMF_Player = GetComponent<MMF_Player>();
     
        if (mySelf.GetComponent<ColorBoxPuzzle>()!= null)
        {
            puzzle = GetComponent<ColorBoxPuzzle>();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && Time.realtimeSinceStartup >=5)
        {
            MMF_Player.PlayFeedbacks();
        }
    }
}
