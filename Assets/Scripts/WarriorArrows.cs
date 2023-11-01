using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorArrows : MonoBehaviour
{
    public float strenght = 0;
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    public AudioSource source;
    public AudioClip clip;

    private bool arrowCheck = false;
    public void Fire()
    {
        arrowCheck = true;
        source.Play();
    }

    private void FixedUpdate()
    {
        if (arrowCheck)
        {
            GameObject bullet_throw = Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            bullet_throw.gameObject.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.gameObject.transform.forward * strenght * Time.deltaTime);
            Destroy(bullet_throw, 7.5f);
            arrowCheck = false;
        }
    }
}
