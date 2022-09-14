using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] PuzzleSolved puzzleSolved;

    [SerializeField] private List<GameObject> doors;
    [SerializeField] private List<GameObject> currentNPC;
    [SerializeField] private List<GameObject> afterEventNPC;

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
        foreach (GameObject npc in currentNPC)
        {
            npc.gameObject.SetActive(false);
        }
        currentNPC.Clear();
        foreach(GameObject npc in afterEventNPC)
        {
            npc.SetActive(true);
        }
        currentNPC = afterEventNPC;
        afterEventNPC.Clear();
    }
}
