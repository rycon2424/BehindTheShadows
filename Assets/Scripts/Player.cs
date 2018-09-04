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
            
           /* //Calculate the distance between all guards and pick the closest
            float distClosest = Mathf.Infinity;
            Guard closest = null;
            Guard[] all = GameObject.FindObjectsOfType<Guard>();
            
            foreach (Guard cur in all)
            {
                float distEnemy = (cur.transform.position - this.transform.position).sqrMagnitude;
                if (distEnemy < distClosest)
                {
                    distClosest = distEnemy;
                    closest = cur;
                }
            }
            //Look at the closest guard
            transform.LookAt(closest.transform.position);*/
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

}
