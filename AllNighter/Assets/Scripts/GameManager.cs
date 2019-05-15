using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        /* 
         if (instance == null)
             instance = this;

         else if(instance != this)
             Destroy(instance.gameObject);
             instance = this;
        */
    }
}
