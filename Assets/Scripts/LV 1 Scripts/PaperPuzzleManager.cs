using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPuzzleManager : MonoBehaviour
{
    [Header("Puzzle NUmber")]
    [SerializeField] public int puzzleNumber;

    private PaperPuzzle PaperPuzzle;
    public GameObject obstacle;

    public delegate void PuzzleSolvedEvent(int puzzleNumber);
    public event PuzzleSolvedEvent OnPuzzleSolved;

    private void Awake()
    {
        PaperPuzzle = FindObjectOfType<PaperPuzzle>();
    }

    private void OnEnable()
    {
        PaperPuzzle.AllPapersPicked += AllPapersPicked;
    }

    private void OnDisable()
    {
        PaperPuzzle.AllPapersPicked -= AllPapersPicked;
    }

    private void AllPapersPicked()
    {
        gameObject.SetActive(false);
        OnPuzzleSolved?.Invoke(puzzleNumber);
    }
}
