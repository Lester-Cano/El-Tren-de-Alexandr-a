using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera enteringSceneCamera;
    [SerializeField] private CinemachineVirtualCamera MainCamera;
    void Start()
    {
        enteringSceneCamera.Priority = 9;
        MainCamera.Priority = 11;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
