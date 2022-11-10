using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperPuzzle : MonoBehaviour
{
    public delegate void PaperEvents();
    public event PaperEvents AllPapersPicked;

    private int count;
    private Paper paperPiece;

    private int missionCompletedOnce;

    private Button interactButton;

    private void Awake()
    {
        interactButton = GameObject.Find("InteractButton").GetComponent<Button>();
    }

    private void Update()
    {
        if(count >= 4)
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
            interactButton.onClick.AddListener(SumToCount);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Analizable"))
        {
            interactButton.onClick.RemoveListener(SumToCount);
        }
    }

    public void SumToCount()
    {
        count++;
        paperPiece = null;

        interactButton.onClick.RemoveListener(SumToCount);
    }
}
