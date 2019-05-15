using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    //Setting the singelton
    public static ObjectiveManager instance = null;

    private Canvas objectiveCanvas;

    void Awake()
    {
        if(instance == null)
            instance = this;

        objectiveCanvas = GameObject.FindGameObjectWithTag("objCanvas").GetComponent<Canvas>();
    }

    void Update()
    {
        
    }
}
