using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    //Setting the singelton
    public static ObjectiveManager instance = null;
    GameManager gameManager;

    private Canvas objectiveCanvas;

    public Objective[] objectives;

    public int progress;

    void Awake()
    {
        instance = this;
        gameManager = GetComponent<GameManager>();
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

    public void addProgress(int addAmount)
    {
        progress = +addAmount;
    }
}
