using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] PuzzleSolved puzzleSolved;

    [SerializeField] private List<GameObject> doors;

    private void OnEnable()
    {
        puzzleSolved.OnPuzzleSolved += OpenDoor;
    }

    private void OnDisable()
    {
        puzzleSolved.OnPuzzleSolved -= OpenDoor;
    }

    public void OpenDoor(int doorNumber)
    {
        doors[doorNumber - 1].gameObject.SetActive(false);
    }
}
