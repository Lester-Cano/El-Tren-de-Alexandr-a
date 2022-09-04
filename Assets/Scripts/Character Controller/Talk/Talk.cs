using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Talk : MonoBehaviour
{
    //Mechanic area

    [SerializeField] public CinemachineVirtualCamera gameCam;

    public GameObject canvas;

    //Input area
    private ThirdPersonActionsAssets playerActionsAssets;
    private InputAction interaction;

    CharacterMechanics characterMechanics;
    ThirdPersonController controller;

    //TMP area

    public GameObject textContainer;
    public TMP_Text text;

    private void Awake()
    {
        playerActionsAssets = new ThirdPersonActionsAssets();
        characterMechanics = GetComponent<CharacterMechanics>();
        controller = GetComponent<ThirdPersonController>();
    }

    private void Start()
    {
        OnDisable();
    }

    private void OnEnable()
    {
        interaction = playerActionsAssets.Player.Interact;
        playerActionsAssets.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionsAssets.Player.Disable();
    }

    public void TalkToNPC(GameObject target)
    {

    }

    public void StopTalking()
    {

    }
}
