using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPuzzleManager : MonoBehaviour
{
    private PaperPuzzle PaperPuzzle;
    public GameObject obstacle;

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
    }
}
