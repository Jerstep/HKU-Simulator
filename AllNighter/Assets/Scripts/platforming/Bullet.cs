using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    private Rigidbody RigidBullet;


    // Start is called before the first frame update
    void Start()
    {
        RigidBullet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RigidBullet.velocity = transform.right * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
