using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineInteractable : MonoBehaviour
{
    Shader outlineShader;
    Shader originalShader;

    private void Start()
    {
        outlineShader = Shader.Find("UltimateOutline");
        originalShader = Shader.Find("Standard");
    }

    public void OutlineObject(Renderer outlineObject, bool lookingAtObject)
    {
        if(lookingAtObject)
            outlineObject.material.shader = outlineShader;
        else
            outlineObject.material.shader = originalShader;
    }
}
