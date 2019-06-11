using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public abstract class Objective : MonoBehaviour
{
    public ObjectiveManager objectiveManager;

    public string objectiveID { get; set; }
    public string objectiveName { get; set; }
    public string objectiveDiscription { get; set; }
    public bool achieved { get; set; }

    //public abstract bool IsAchieved();
    public abstract void Complete();
    public abstract void DrawHUD(GameObject objective_UI);
    public abstract string GetName();
}
