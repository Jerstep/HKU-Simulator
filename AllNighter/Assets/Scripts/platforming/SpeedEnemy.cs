using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEnemy : MonoBehaviour
{
    public float range = 10f;
    public bool moving;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if(hit.collider.gameObject.tag == "Player" && !moving)
            {
                Debug.Log("hey there remco the player has been hit");
                moving = true;
            }
        }

        if (moving)
        {
            transform.Translate((Vector3.forward * speed) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<PlatformingPlayer>().RestartPos();
        }

    }
}
