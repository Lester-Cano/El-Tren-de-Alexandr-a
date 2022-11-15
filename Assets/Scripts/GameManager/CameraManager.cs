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
        Invoke("ChangePriority",1.5f);
    }
    void ChangePriority()
    {
        enteringSceneCamera.Priority = 9;
        MainCamera.Priority = 11;
    }
}
