using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    //Visual effect modifiers for player
    private float amountJitter;
    private float amountVinget;

    //Basic player stats
    private float walkSpeed;

    public float energy;

    //Setting the singelton
    public static PlayerStateManager instance = null;
    EndStats results;

    void Awake()
    {
        
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        results = GameObject.Find("Resultholder").GetComponent<EndStats>();
    }
    private void Update()
    {
        energy -= Time.deltaTime;
        if(energy <= 0)
        {
            EnergyDepleted();
        }
    }

    void EnergyDepleted()
    {
        results.GrabStatus();
    }


}
