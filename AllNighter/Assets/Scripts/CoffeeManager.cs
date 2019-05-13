using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeManager : MonoBehaviour
{
    private float energy;
    private float coffeeAmount;

    //Setting the singelton
    public static CoffeeManager instance = null;

    void Awake()
    {
        if(instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if(instance != this)
            Destroy(gameObject);
    }
}
