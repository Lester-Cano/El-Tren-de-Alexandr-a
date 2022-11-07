using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    MissionManager missionManager;
    [SerializeField] public int phaseNumber;

    public delegate void OnSetPhases(int s);
    public event OnSetPhases OnSetPhase;

    private void Awake()
    {
        missionManager = FindObjectOfType<MissionManager>();
    }

    private void OnEnable()
    {
        missionManager.OnSendConditions += SetPhase;
    }

    private void OnDisable()  
    {
        missionManager.OnSendConditions -= SetPhase;
    }

    public void SetPhase(List<bool> conditions)
    {
        var count = 0;

        foreach (var condition in conditions)
        {
            if(condition == true)
            {
                count++;
            }
        }

        phaseNumber = count;

        OnSetPhase?.Invoke(phaseNumber);
    }
}
