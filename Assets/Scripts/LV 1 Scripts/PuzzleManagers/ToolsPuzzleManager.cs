using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsPuzzleManager : MonoBehaviour
{
    [Header("Puzzle Number")]
    [SerializeField] public int puzzleNumber;

    private ColorChecker toolPuzzle;
    public GameObject teleporterToActive;

    public delegate void PuzzleSolvedEvent(int puzzleNumber);
    public event PuzzleSolvedEvent OnPuzzleSolved;

    private void Awake()
    {
        toolPuzzle = FindObjectOfType<ColorChecker>();
    }

    private void OnEnable()
    {
        toolPuzzle.AllToolsPicked += AllObjetivesPicked;
    }

    private void OnDisable()
    {
        toolPuzzle.AllToolsPicked -= AllObjetivesPicked;
    }

    private void AllObjetivesPicked()
    {
        teleporterToActive.SetActive(true);
        OnPuzzleSolved?.Invoke(puzzleNumber);
    }
}
