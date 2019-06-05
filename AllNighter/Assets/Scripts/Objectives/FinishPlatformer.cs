using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlatformer : Objective
{
    //Pure Testing

    public bool hasFinishedPlatformer;
    public AudioClip trumpetSound;

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

    public override void DrawHUD()
    {
        GUILayout.Label(string.Format("Finished Cource {0}", hasFinishedPlatformer));
    }
}
