using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    //Declare variables
    public Transform player;
    public Transform handle;
    public Transform background;

    private Vector2 pointA;
    private Vector2 pointB;

    public float speed = 5.0f;
    private bool touchStart = false;




	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            handle.transform.position = background.transform.position * 1;
            background.transform.position = pointA * 1;
            //Show joystick on screen
            handle.GetComponent<SpriteRenderer>().enabled = true;
            background.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
	}

    private void FixedUpdate()
    {
        if (touchStart)
        {
            //Player movement
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            MoveCharacter(direction * 1);
            handle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * 1;
        }
        else
        {
            //Joystick invisible 
            handle.GetComponent<SpriteRenderer>().enabled = false;
            background.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void MoveCharacter(Vector2 direction)
    {
        //Walk
        player.Translate(direction * speed * Time.deltaTime);
    }
}
