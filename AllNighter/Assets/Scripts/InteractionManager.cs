using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    Camera cam;
    float interactDistance = 3f;    

    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        RayCast();
    }

    private void RayCast()
    {
        int layerMask = ~(1 << 9);

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, interactDistance, layerMask))
        {
            //print("I'm looking at " + hit.transform.name);

            if(hit.transform.CompareTag("Energy"))
            {

            }
        }
        else
        {
            print("I'm looking at nothing!");
        }
        Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * interactDistance, Color.red);
    }    

    void TaskViewer()
    {

    }
}
