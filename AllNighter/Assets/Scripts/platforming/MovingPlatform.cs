using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool movingLeftRight;

    public bool up, right;

    public float switchTime;



    // Start is called before the first frame update
    void Start()
    {
        if(movingLeftRight)
            StartCoroutine(rightTrue());
        else
            StartCoroutine(UpTrue());
    }

    // Update is called once per frame
    void Update()
    {
        if (!movingLeftRight)
        {
            if (up)
                transform.Translate(Vector3.up * Time.deltaTime);
            else
                transform.Translate(Vector3.up * -Time.deltaTime);
        }
        else if (movingLeftRight)
        {
            if (right)
                transform.Translate(Vector3.right * Time.deltaTime);
            else
                transform.Translate(Vector3.right * -Time.deltaTime);
        }

        
    }

    IEnumerator UpTrue()
    {
        StopCoroutine(UpFalse());
        up = true;
        yield return new WaitForSeconds(switchTime);
        StartCoroutine(UpFalse());
    }
    IEnumerator UpFalse()
    {
        StopCoroutine(UpTrue());
        up = false;
        yield return new WaitForSeconds(switchTime);
        StartCoroutine(UpTrue());
    }

    IEnumerator rightTrue()
    {
        StopCoroutine(rightFalse());
        right = true;
        yield return new WaitForSeconds(switchTime);
        StartCoroutine(rightFalse());
    }
    IEnumerator rightFalse()
    {
        StopCoroutine(rightTrue());
        right = false;
        yield return new WaitForSeconds(switchTime);
        StartCoroutine(rightTrue());
    }
}
