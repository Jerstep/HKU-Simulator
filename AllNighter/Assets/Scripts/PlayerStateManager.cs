﻿using System.Collections;
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

    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    private void Update()
    {
        energy -= Time.deltaTime;
    }

    void EnergyDepleted()
    {

    }


}
