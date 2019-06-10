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

    [SerializeField]
    private Objective[] availebleObjectives;

    public List<Objective> activeObjectives;

    public int progress;

    int objectiveIndex = 0;
    bool coroutineActive;
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
        if(objectiveIndex < availebleObjectives.Length && !coroutineActive && activeObjectives.Count < 5)
        {
            StartCoroutine(AddNewObjective());
        }

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

        GameObject objective_UI_Instance = Instantiate(objective_UI);
        objective_UI_Instance.transform.SetParent(objectives_UI.transform);
        objective_UI_Instance.transform.localScale = new Vector3(1, 1, 1);
        activeObjectives[objectiveIndex].DrawHUD(objective_UI_Instance);
        
        // Lowers the time till next objective
        waitTimeToNextObjective -= (waitTimeToNextObjective / 90f);
        objectiveIndex++;

        coroutineActive = true;
        yield return new WaitForSeconds(waitTimeToNextObjective);
        coroutineActive = false;
    }
}
