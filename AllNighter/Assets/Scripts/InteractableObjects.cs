using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour, IInteracteble
{
    public string ReturnName()
    {
        return this.transform.name;
    }
}
