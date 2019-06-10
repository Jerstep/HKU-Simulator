using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeDone : MonoBehaviour
{
    Material origialMaterial;
    public Material coffeeDoneMaterial;

    Renderer thisRendered;

    // Start is called before the first frame update
    void Awake()
    {
        thisRendered = GetComponent<Renderer>();
        origialMaterial = thisRendered.material;
    }

    public void SetMaterialDone()
    {
        thisRendered.material = coffeeDoneMaterial;
    }

    public void SetMaterialOriginal()
    {
        thisRendered.material = origialMaterial;
    }
}
