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
            other.GetComponent<Enemy>().Die();
            Destroy(gameObject);
        }

        if (other.tag == "SpeedEnemy" && !enemyBullet)
        {
            other.GetComponent<SpeedEnemy>().Die();
            Destroy(gameObject);
        }

        if (other.tag == "Player" && enemyBullet)
        {
            FindObjectOfType<GameManager>().energy -= 5;
            Destroy(gameObject);
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);

    }
}
