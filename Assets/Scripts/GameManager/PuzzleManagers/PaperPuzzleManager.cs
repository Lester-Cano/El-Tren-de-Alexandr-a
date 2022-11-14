using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPuzzleManager : MonoBehaviour
{
    [Header("Puzzle Number")]
    [SerializeField] public int puzzleNumber;
    [SerializeField] Transform[] Puzzle1;
    private SpawnFox foxScript;

    private PaperPuzzle PaperPuzzle;
    public GameObject teleporterToActive;

    public delegate void PuzzleSolvedEvent(int puzzleNumber);
    public event PuzzleSolvedEvent OnPuzzleSolved;

    private void Awake()
    {
        foxScript = FindObjectOfType<SpawnFox>();
        PaperPuzzle = FindObjectOfType<PaperPuzzle>();
    }

    private void OnEnable()
    {
        PaperPuzzle.AllPapersPicked += AllObjetivesPicked;
    }

    private void OnDisable()
    {
        PaperPuzzle.AllPapersPicked -= AllObjetivesPicked;
    }

    private void AllObjetivesPicked()
    {
        teleporterToActive.SetActive(true);
        OnPuzzleSolved?.Invoke(puzzleNumber);
        foxScript.SpawningFox(Puzzle1);
    }
}
