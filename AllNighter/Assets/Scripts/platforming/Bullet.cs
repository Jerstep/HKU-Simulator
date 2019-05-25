using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool enemyBullet;
    public float speed;
    private Rigidbody RigidBullet;
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        RigidBullet = GetComponent<Rigidbody>();
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        RigidBullet.velocity = transform.right * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && !enemyBullet)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.tag == "Player" && enemyBullet)
        {
            other.GetComponent<PlatformingPlayer>().hp -= 10;
            Destroy(gameObject);
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);

    }
}
