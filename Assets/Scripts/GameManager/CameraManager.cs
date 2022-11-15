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
        Invoke("changePriority", 0.5f);
    }
    private void changePriority()
    {
        enteringSceneCamera.Priority = 9;
        MainCamera.Priority = 11;
    }
}
