using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    GameManager gameManager;
    UIManager uiManager;

    public GameObject objective_UI;
    public GameObject objectives_UI;
    public GameObject[] Buttons_UI;

    [SerializeField]
    private Objective[] availebleObjectives;

    public List<Objective> activeObjectives;
    public List<GameObject> UIObjectives;

    public float progress;

    public int objectiveIndex = 0;
    bool coroutineActive;
    public float waitTimeToNextObjective;

    public bool objectiveDone = false;

    void Awake()
    {
        gameManager = GetComponent<GameManager>();
        uiManager = GetComponent<UIManager>();
        NewObjective();
    }

    void NewObjective()
    {
        objectiveDone = false;
        activeObjectives.Add(availebleObjectives[objectiveIndex]);

        GameObject objective_UI_Instance = Instantiate(objective_UI);
        UIObjectives.Add(objective_UI_Instance);
        objective_UI_Instance.transform.SetParent(objectives_UI.transform);
        objective_UI_Instance.transform.localScale = new Vector3(1, 1, 1);
        activeObjectives[objectiveIndex].DrawHUD(objective_UI_Instance);
        activeObjectives[objectiveIndex].objectiveManager = this;
        activeObjectives[objectiveIndex].achieved = false;
        Debug.Log(objectiveIndex);
    }

    void Update()
    {
        if(objectiveIndex < availebleObjectives.Length - 1 && objectiveDone && activeObjectives.Count < 5)
        {
            NewObjective();
        }

        for(int i = 0; i < activeObjectives.Count; i++)
        {
            if(activeObjectives[i].achieved)
            {
                Debug.Log("objective complete");
                uiManager.SetMinigamesFalse();
                activeObjectives[i].Complete();
                objectiveDone = true;

                activeObjectives.Remove(activeObjectives[i]);
                Destroy(UIObjectives[i]);
                UIObjectives.Remove(UIObjectives[i]);

                //if(objectiveIndex < availebleObjectives.Length - 1)
                //{
                //    objectiveIndex++;
                //}
            }
        }
    }

    public void addProgress(int addAmount)
    {
        progress += addAmount;
        Debug.Log(progress);
    }

    //This is going to be ugly but there is no time >~<
    public void SetButtons(Objective objective)
    {
        for(int i = 0; i < Buttons_UI.Length -1; i++)
        {
            //if(objective.GetName() == Buttons_UI[i].)
            //{

            //}
        }        
    }
}
