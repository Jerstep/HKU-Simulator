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

    //Refrences to importaint Managers
    private PlayerStateManager playerState;

    void Awake()
    {
        if(instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if(instance != this)
            Destroy(gameObject);

        playerState = GetComponent<PlayerStateManager>();
    }


    private void Update()
    {
        energy -= Time.deltaTime;
    }

    void EnergyDepleted()
    {

    }


}
