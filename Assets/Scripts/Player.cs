using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Declare variables
    public GameObject pauseScreen;
    public bool isPaused;

    public GameObject joystick;

    void Start ()
    {
	}

    void Update()
    {

    }

    public void Use()
    {
        Debug.Log("Use");
        //Type here what to do
    }

    public void Peek()
    {
        Debug.Log("Peek");
        //Type here what to do
    }

    public void Pause()
    {
        joystick.SetActive(false);
        if (!isPaused)
        {
            pauseScreen.SetActive(false);
            isPaused = true;
        }
        else
        {
            pauseScreen.SetActive(true);
            isPaused = false;
        }
    }

}
