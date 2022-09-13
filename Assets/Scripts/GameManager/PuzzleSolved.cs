using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public delegate void OnPuzzleSolved(int doorNumber);

public class PuzzleSolved : MonoBehaviour
{
    //Events Area
    public event OnPuzzleSolved OnPuzzleSolved;
    [SerializeField] private int puzzleNumber;

    //Interactions Area
    private ThirdPersonActionsAssets playerActionsAssets;
    private bool foundKeyObject;
    [SerializeField] HUDManager hudManager;

    private void OnEnable()
    {
        playerActionsAssets.Player.Interact.Enable();
    }

    private void OnDisable()
    {
        playerActionsAssets.Player.Interact.Disable();
    }

    private void Awake()
    {
        playerActionsAssets = new ThirdPersonActionsAssets();
    }

    private void Update()
    {
        if (playerActionsAssets.Player.Interact.triggered && foundKeyObject)
        {
            SolvedPuzzle(puzzleNumber);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("KeyObject"))
        {
            foundKeyObject = true;
            var holder = other.gameObject.GetComponent<PuzzleKeyCode>();
            puzzleNumber = holder.keyCode;
            hudManager.textFadein();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("KeyObject"))
        {
            foundKeyObject = false;
            hudManager.textFadeout();
        }
    }

    public void SolvedPuzzle(int doorNumber)
    {
        if (OnPuzzleSolved != null)
        {
            OnPuzzleSolved(doorNumber);
        }
    }
}
