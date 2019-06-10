using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyObject : MonoBehaviour
{
    InteractableObjects interactableObject;
    public bool isReady;

    private void Awake()
    {
        interactableObject = GetComponent<InteractableObjects>();
    }
}
