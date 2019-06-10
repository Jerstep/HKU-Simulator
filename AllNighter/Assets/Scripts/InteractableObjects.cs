using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour, IInteracteble
{
    public bool isHighlighted = false;
    Shader origialShader;
    public Shader outlineShader;

    public Renderer thisRenderer;

    public string ID;

    private void Awake()
    {
        thisRenderer = GetComponent<Renderer>();
        origialShader = thisRenderer.material.shader;
        outlineShader = Shader.Find("Shader Graphs/OutlineShader");
    }

    private void LateUpdate()
    {
        if(isHighlighted)
        {
            if(thisRenderer.material.shader != outlineShader)
            {
                thisRenderer.material.shader = outlineShader;
                Debug.Log("Highlighted");
            }
        }
        else
        {
            if(thisRenderer.material.shader != origialShader)
            {
                thisRenderer.material.shader = origialShader;
                Debug.Log("Not Highlighted");
            }
        }
        isHighlighted = false;
    }

    public string ReturnName()
    {
        return this.transform.name;
    }

}
