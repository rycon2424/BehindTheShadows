﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool isShooting;

    public Bullet bullet;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotTimer;

    public Transform firePoint;

    public AudioSource shotAudio;

    void Start()
    {
        shotAudio = GetComponent<AudioSource>();
    }

    void Update ()
    {
		if (isShooting)
        {
            shotTimer -= Time.deltaTime;
            if (shotTimer <= 0)
            {
                shotTimer = timeBetweenShots;
                Bullet newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Bullet;
                shotAudio.Play();
                newBullet.speed = bulletSpeed;
            }
        }
        else
        {
            shotTimer = 0;
        }
    }
}
