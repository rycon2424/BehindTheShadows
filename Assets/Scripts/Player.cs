using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                Rotate();

            }
            if (Input.GetMouseButtonUp(0))
            {
                gun.isShooting = false;
            }
        }
    }

    void Rotate()
    {
        //Rotate the player towards input 
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.y = transform.rotation.y;
        transform.LookAt(mousePos);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End")
        {
            SceneManager.LoadScene(2);
        }
    }
}
