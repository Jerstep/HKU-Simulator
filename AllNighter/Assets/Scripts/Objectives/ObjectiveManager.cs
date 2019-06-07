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

    public Objective[] availebleObjectives;
    public List<Objective> activeObjectives;

    public int progress;

    int objectiveIndex;
    public float waitTimeToNextObjective;


    void Awake()
    {
        //instance = this;
        gameManager = GetComponent<GameManager>();
        objectiveCanvas = FindObjectOfType<Canvas>();
    }

    void NewObjective()
    {
    }

    void Update()
    {
        foreach(Objective objective in activeObjectives)
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

    public IEnumerator AddNewObjective()
    {
        activeObjectives.Add(availebleObjectives[objectiveIndex]);

        //GameObject objective_UI_Instance = Instantiate(objective_UI);
        //objective_UI_Instance.transform.parent = objectives_UI.transform;
        //objective.DrawHUD(objective_UI_Instance);

        yield return new WaitForSeconds(waitTimeToNextObjective);
        // Lowerst the time till next objective;
        waitTimeToNextObjective -= (waitTimeToNextObjective / 90f);
        objectiveIndex++;
    }
}
