using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Declare variables
    protected JoyButton joybutton;
    protected bool use;

	void Start ()
    {
        joybutton = FindObjectOfType<JoyButton>();
	}

    void Update()
    {
        if (!use && joybutton.Pressed)
        {
            use = true;
            //Type here what to do
        }

        if (use && !joybutton.Pressed)
        {
            use = false;
        }
    }
}
