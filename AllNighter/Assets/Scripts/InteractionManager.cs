using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Camera cam;
    float interactDistance = 3f;

    GameManager gameManager;

    void Awake()
    {
        //cam = FindObjectOfType<Camera>();
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        RayCast();

        if(InputManager.GetKeyDown("Quit"))
        {
            gameManager.LeftPc();
        }           
    }

    private void RayCast()
    {
        int layerMask = ~(1 << 9);

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, interactDistance, layerMask))
        {
            if(hit.transform.CompareTag("Interactable"))
            {
                CheckObjectID(hit.collider.gameObject.GetComponent<InteractableObjects>());
            }
        }
        else
        {
            //print("I'm looking at nothing!");
        }
        Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * interactDistance, Color.red);
    }    


    void CheckObjectID(InteractableObjects interactableObject)
    {
        string ID = interactableObject.ID;

        if(ID == "PC")
        {
            if(InputManager.GetKeyDown("Interact"))
            {
                gameManager.BehindPc();
            }

            if(!gameManager.IsPlayerBehindPc())
            {
                HighlightObject(interactableObject);
            }
        }

        if(ID == "CoffeeCan")
        {
            if(gameManager.coffeeDone)
            { 
                HighlightObject(interactableObject);
                if(InputManager.GetKeyDown("Interact"))
                {
                    gameManager.ResetCoffeeMachine();
                    gameManager.AddEnergy(40);
                    gameManager.coffeeDone = false;
                }
            }
        }

        if(ID == "CoffeeMachine")
        {
            if(!gameManager.makinCoffee)
            {
                HighlightObject(interactableObject);
            }

            if(InputManager.GetKeyDown("Interact"))
            {
                gameManager.makinCoffee = true;
            }
        }
    }

    void HighlightObject(InteractableObjects interactableObject)
    {
        interactableObject.isHighlighted = true;
    }

    void TaskViewer()
    {

    }
}
