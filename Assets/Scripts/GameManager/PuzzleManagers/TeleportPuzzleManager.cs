using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPuzzleManager : MonoBehaviour
{
    [Header("Puzzle Number")]
    [SerializeField] public int puzzleNumber;
    [SerializeField] Transform[] Puzzle3;
    private SpawnFox foxScript;
    private TeleportPuzzle teleportPuzzle;
    public GameObject teleporterToActive, sceneToActive;

    public delegate void PuzzleSolvedEvent(int puzzleNumber);
    public event PuzzleSolvedEvent OnPuzzleSolved;

    private void Awake()
    {
        foxScript = FindObjectOfType<SpawnFox>();
        teleportPuzzle = FindObjectOfType<TeleportPuzzle>();
    }

    private void OnEnable()
    {
        teleportPuzzle.MazeCompleted += AllObjetivesPicked;
    }

    private void OnDisable()
    {
        teleportPuzzle.MazeCompleted -= AllObjetivesPicked;
    }

    private void AllObjetivesPicked()
    {
        teleporterToActive.SetActive(true);
        sceneToActive.SetActive(true);
        OnPuzzleSolved?.Invoke(puzzleNumber);
    }
}
