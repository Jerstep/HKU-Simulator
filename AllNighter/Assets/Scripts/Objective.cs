using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private string objName;
    private int objectiveID;

    private Image progressBar;
    private List<bool> objectiveStates;
    private bool objectiveFinished;

    public void SetObjectiveState(int index, bool state)
    {
        objectiveStates[index] = state;
        CheckAllObjectives();
    }

    public void SetObjectiveName(string name)
    {
        objName = name;
    }

    private void CheckAllObjectives()
    {
        for(int i = 0; i < objectiveStates.Count; i++)
        {
            if(!objectiveStates[i])
            {
                break;
            }
        }

        Debug.Log("Passed Check Loop");
        objectiveFinished = true;
    }
}
