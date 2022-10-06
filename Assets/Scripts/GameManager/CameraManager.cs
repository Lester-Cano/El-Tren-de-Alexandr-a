using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera enteringSceneCamera;
    void Start()
    {
        enteringSceneCamera.Priority = 9;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
