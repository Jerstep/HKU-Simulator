using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinishCollider : MonoBehaviour
{
    public ObjectiveManager objectiveManager;

    private void Awake()
    {
        objectiveManager = FindObjectOfType<ObjectiveManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Colission");
        if(other.CompareTag("PlatformingPlayer"))
        {
            print("Colission Player");
            //objectiveManager.activeObjectives[0].IsAchieved();
        }
    }
}
