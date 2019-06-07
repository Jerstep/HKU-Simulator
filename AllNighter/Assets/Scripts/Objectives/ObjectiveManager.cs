using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    //Setting the singelton
    //public static ObjectiveManager instance;
    GameManager gameManager;

    private Canvas objectiveCanvas;
    public GameObject objective_UI;
    public GameObject objectives_UI;

    public List<Objective> objectives;

    public int progress;

    void Awake()
    {
        //instance = this;
        gameManager = GetComponent<GameManager>();
        objectiveCanvas = FindObjectOfType<Canvas>();
    }

    void OnGUI()
    {
        foreach(var objective in objectives)
        {
            GameObject objective_UI_Instance = Instantiate(objective_UI);
            objective_UI_Instance.transform.parent = objectives_UI.transform;
            objective.DrawHUD(objective_UI_Instance);
        }
    }

    void Update()
    {
        foreach(Objective objective in objectives)
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
        progress =+ addAmount;
    }
}
