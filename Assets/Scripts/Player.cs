using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Declare variables
    public enum GameType {Normal, Minigame1};
    public GameType type;

    public Gun gun;

    public bool canUse = false;
    public bool canPeek = false;

    public bool isLooking;

    void Start ()
    {

	}

    void Update()
    {
        //Minigame 1
        if (type == GameType.Minigame1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                gun.isShooting = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                gun.isShooting = false;
            }  
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            //You're able to use the door or peek
            canUse = true;
            canPeek = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            //You're not able to use the door or peek
            canUse = false;
            canPeek = false;
        }
    }
    //
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Guard")
        {
            transform.LookAt(other.transform.position);
            isLooking = false;
        }
    }
}
