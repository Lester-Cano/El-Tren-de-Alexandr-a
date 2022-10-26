using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] 
    public List<bool> missionList;

    PaperPuzzleManager paperPuzzleManager;

    public delegate void OnSetDialogue(List<bool> conditions);
    public event OnSetDialogue OnSendConditions;

    private void Awake()
    {
        paperPuzzleManager = FindObjectOfType<PaperPuzzleManager>();
    }

    private void OnEnable()
    {
        paperPuzzleManager.OnPuzzleSolved += PuzzleSolved;
    }

    private void OnDisable()
    {
        paperPuzzleManager.OnPuzzleSolved -= PuzzleSolved;
    }

    public void PuzzleSolved(int puzzleNumber)
    {
        missionList[puzzleNumber - 1] = true;

        OnSendConditions?.Invoke(missionList);
    }
}
