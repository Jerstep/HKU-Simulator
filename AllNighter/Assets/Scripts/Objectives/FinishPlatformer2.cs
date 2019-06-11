using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishPlatformer2 : Objective
{
    public new bool achieved = false;

    public AudioClip finishSHound;
    public AudioClip startSound;

    [Header("UI texts that shows up in game")]
    public string ID;
    public string name;
    public string discription;

    //public ObjectiveManager objectiveManager;

    void Awake()
    {
        GetComponent<AudioSource>().PlayOneShot(startSound);
    }

    public override string GetName()
    {
        return ID;
    }

    public override void Complete()
    {
        objectiveManager.addProgress(20);
        GetComponent<AudioSource>().PlayOneShot(finishSHound);
    }

    public override void DrawHUD(GameObject objective_UI)
    {
        TMP_Text[] objectiveUIText = objective_UI.GetComponentsInChildren<TMP_Text>();
        objectiveUIText[0].text = name;
        objectiveUIText[1].text = discription;
    }

    public override void DrawButton(GameObject ButtonPrefab)
    {
        ButtonPrefab.SetActive(true);
    }
}
