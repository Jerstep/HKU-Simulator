using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if(instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if(instance != this)
            Destroy(gameObject);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
