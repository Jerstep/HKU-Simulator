using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    //Setting the singelton
    public static ObjectiveManager instance = null;

    void Awake()
    {
        if(instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if(instance != this)
            Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
