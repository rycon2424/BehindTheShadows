using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodCanvas : MonoBehaviour {

    public static bool Blood;
    public GameObject bloodCanvas;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Blood == true)
        {
            bloodCanvas.SetActive(true);
        }

        if (Blood == false)
        {
            bloodCanvas.SetActive(false);
        }
	}
}
