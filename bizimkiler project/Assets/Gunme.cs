using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunme : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
  //  AudioSource audioSource;

    public float nextTimeToFire = 0f;
    public float fireRate = 1f;
   // public AudioClip impact;

    private void Start()
    {
    //    audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
           // audioSource.PlayOneShot(impact, 0.7F);
            nextTimeToFire = Time.time + (1f / fireRate);
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }

}