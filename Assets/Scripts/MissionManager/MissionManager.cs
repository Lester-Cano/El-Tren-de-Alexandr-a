using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] 
    public List<bool> missionList;

    PaperPuzzleManager paperPuzzleManager;
    ToolsPuzzleManager toolsPuzzleManager;
    TeleportPuzzleManager teleportPuzzleManager;

    public delegate void OnSetDialogue(List<bool> conditions);
    public event OnSetDialogue OnSendConditions;

    private void Awake()
    {
        paperPuzzleManager = FindObjectOfType<PaperPuzzleManager>();
        toolsPuzzleManager = FindObjectOfType<ToolsPuzzleManager>();
        teleportPuzzleManager = FindObjectOfType<TeleportPuzzleManager>();
    }

    private void OnEnable()
    {
        if (paperPuzzleManager != null && toolsPuzzleManager != null && teleportPuzzleManager != null)
        {
            paperPuzzleManager.OnPuzzleSolved += PuzzleSolved;
            toolsPuzzleManager.OnPuzzleSolved += PuzzleSolved;
            teleportPuzzleManager.OnPuzzleSolved += PuzzleSolved;
        }
    }

    private void OnDisable()
    {
        if (paperPuzzleManager != null && toolsPuzzleManager != null && teleportPuzzleManager != null)
        {
            paperPuzzleManager.OnPuzzleSolved -= PuzzleSolved;
            toolsPuzzleManager.OnPuzzleSolved -= PuzzleSolved;
            teleportPuzzleManager.OnPuzzleSolved -= PuzzleSolved;
        }
    }

    public void PuzzleSolved(int puzzleNumber)
    {
        missionList[puzzleNumber - 1] = true;

        OnSendConditions?.Invoke(missionList);
    }
}
