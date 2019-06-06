using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishPlatformer : Objective
{
    //Pure Testing

    public bool hasFinishedPlatformer = false;
    public AudioClip trumpetSound;

    [Header("UI texts that shows up in game")]
    public string objectiveName;
    public string objectiveDiscription;

    ProgressManager progressManager;

    void Awake()
    {
        progressManager = GetComponent<ProgressManager>();
    }

    public override bool IsAchieved()
    {
        return (hasFinishedPlatformer == true);
    }

    public override void Complete()
    {
        progressManager.addProgress(20);
        GetComponent<AudioSource>().PlayOneShot(trumpetSound);
    }

    public override void DrawHUD(GameObject objective_UI)
    {
        //GUILayout.Label(string.Format("Finished Cource {0}", hasFinishedPlatformer));
        TMP_Text[] objectiveUIText = objective_UI.GetComponentsInChildren<TMP_Text>();
        objectiveUIText[0].text = objectiveName;
        objectiveUIText[1].text = objectiveDiscription;
    }
}

/* Finish the platformer:
 *  Got to your pc and playtest the game;
  
 */
