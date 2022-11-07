using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChecker : MonoBehaviour
{
    [SerializeField] int valueToGet;
    public int actualValue;

    public delegate void ToolsEvents();
    public event ToolsEvents AllToolsPicked;

    private int missionCompletedOnce;

    private void Update()
    {
        if(actualValue == valueToGet)
        {
            missionCompletedOnce++;

            if (missionCompletedOnce <= 1)
            {
                AllToolsPicked?.Invoke();
            }
        }
    }
}
