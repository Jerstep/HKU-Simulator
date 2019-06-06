using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public abstract class Objective : MonoBehaviour
{
    public abstract bool IsAchieved();
    public abstract void Complete();
    public abstract void DrawHUD(GameObject objective_UI);
}
