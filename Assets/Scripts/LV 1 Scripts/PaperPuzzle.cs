using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPuzzle : MonoBehaviour
{
    public delegate void PaperEvents();
    public event PaperEvents AllPapersPicked;

    private int count;
    private Paper paperPiece;

    private int missionCompletedOnce;

    private void Update()
    {
        if(count >= 8)
        {
            missionCompletedOnce++;

            if(missionCompletedOnce <= 1)
            {
                AllPapersPicked?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        paperPiece = other.GetComponent<Paper>();
        if (other.CompareTag("Analizable") && paperPiece != null)
        {
            count++;
            paperPiece = null;
        }
    }
}
