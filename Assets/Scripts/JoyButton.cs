using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    //Declare variables
    [HideInInspector]
    public bool Pressed;            //Check button activity
    public GameObject joystick;    

    public void OnPointerUp(PointerEventData eventData)
    {
        //Button is not active
        Pressed = false;
        //Joystick is active
        joystick.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Button is active
        Pressed = true;
        //Joystick is not active
        joystick.SetActive(false);
    }

}
