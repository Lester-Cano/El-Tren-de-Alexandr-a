using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsPuzzleManager : MonoBehaviour
{
    [Header("Puzzle Number")]
    [SerializeField] public int puzzleNumber;
    [SerializeField] Transform[] Puzzle2;
    private SpawnFox foxScript;
    private ColorChecker toolPuzzle;
    public GameObject teleporterToActive, destroyedTree, fixedTree;

    public delegate void PuzzleSolvedEvent(int puzzleNumber);
    public event PuzzleSolvedEvent OnPuzzleSolved;

    private void Awake()
    {
        foxScript = FindObjectOfType<SpawnFox>();
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
        destroyedTree.SetActive(false);
        fixedTree.SetActive(true);
        OnPuzzleSolved?.Invoke(puzzleNumber);
    }
}
