using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Declare variables
    public bool canUse = false;
    public bool canPeek = false;

    void Start ()
    {

	}

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "test")
        {
            canUse = true;
            canPeek = true;
        }
    }

}
