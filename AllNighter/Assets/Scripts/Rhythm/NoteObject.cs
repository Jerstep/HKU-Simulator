using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    public bool isEnergyNote;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                
                gameObject.SetActive(false);

                //RhythmGameManager.instance.NoteHit();
                if (Mathf.Abs(transform.position.y) > 0.25)
                {
                    Debug.Log("hit");
                    RhythmGameManager.instance.NormalHit(isEnergyNote);
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    
                }
                else if(Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("good");
                    RhythmGameManager.instance.GoodHit(isEnergyNote);
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("perfect");
                    RhythmGameManager.instance.PerfectHit(isEnergyNote);
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            RhythmGameManager.instance.NoteMiss();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
