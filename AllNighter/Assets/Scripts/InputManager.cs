using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;

    private PlayerMovement playerMovement;

    void Awake()
    {
        if(instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if(instance != this)
            Destroy(gameObject);

        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
}
