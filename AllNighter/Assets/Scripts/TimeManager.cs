using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float timeScale = 1;

    //Rotation Angles for sun
    public float xAngle, yAngle, zAngle;

    private bool canRotate = false;

    public GameObject sun;


    PlayerStateManager playerState;
    ObjectiveManager objectiveManager;

    void Awake()
    {
        playerState = GetComponent<PlayerStateManager>();
        objectiveManager = GetComponent<ObjectiveManager>();
    }

    void Update()
    {
        StartCoroutine(DayCycle());
        DisplayTime();
    }

    void DisplayTime()
    {

       

    }

    IEnumerator DayCycle()
    {
        canRotate = true;
        yield return new WaitForSeconds(timeScale);
        if(canRotate)
        {
            sun.transform.Rotate(xAngle, yAngle, zAngle);
            canRotate = false;
        }
        canRotate = false;
    }
}
