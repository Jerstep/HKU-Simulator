using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab, energyPowerup;
    public Transform firePos1;
    public float waitTime;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitTime());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitTime()
    {
        
        yield return new WaitForSeconds(waitTime);
        Shoot();
    }

    void Shoot()
    {
        StopCoroutine(WaitTime());
        Instantiate(bulletPrefab, firePos1.position, firePos1.rotation);
        StartCoroutine(WaitTime());
    }

    public void Die()
    {

        Instantiate(energyPowerup, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
