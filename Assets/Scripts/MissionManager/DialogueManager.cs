using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    MissionManager missionManager;
    [SerializeField] public int phaseNumber;

    [SerializeField] public List<GameObject> npcList1;
    [SerializeField] public List<GameObject> npcList2;

    private void Awake()
    {
        missionManager = FindObjectOfType<MissionManager>();
    }

    private void Start()
    {

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
        Debug.Log("Changing Phase");

        var count = 0;

        foreach (var condition in conditions)
        {
            if(condition == true)
            {
                count++;
            }
        }

        phaseNumber = count;

        SetCurrentNpc(phaseNumber);
    }

    public void SetCurrentNpc(int phase)
    {
        for (int i = 0; i < npcList1.Count; i++)
        {
            if (i == phase)
            {
                npcList1[i].gameObject.SetActive(true);
                npcList2[i].gameObject.SetActive(true);
            }
            else
            {
                npcList1[i].gameObject.SetActive(false);
                npcList2[i].gameObject.SetActive(false);
            }
        }
    }
}
