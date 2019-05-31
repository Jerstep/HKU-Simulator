using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    //Setting the singelton
    public static ObjectiveManager instance = null;

    private Canvas objectiveCanvas;

    public Objective[] objectives;

    void Awake()
    {
        objectives = GetComponents<Objective>();
    }

    void OnGUI()
    {
        foreach(var objective in objectives)
        {
            objective.DrawHUD();
        }
    }

    void Update()
    {
        foreach(var objective in objectives)
        {
            if(objective.IsAchieved())
            {
                objective.Complete();
                Destroy(objective);
            }
        }
    }
}
