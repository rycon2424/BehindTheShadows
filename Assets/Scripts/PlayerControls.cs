using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public bool walk;
    public GameObject doorText;
    public bool door;
    public bool againstDoor;

    public float playerSpeed;

    private void Start()
    {
        doorText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (walk)
        {
            transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
        }
    }

    public void Left()
    {
        walk = true;
        transform.rotation = new Quaternion(0, 0, 0.707f, 0.707f);
    }

    public void Right()
    {
        walk = true;
        transform.rotation = new Quaternion(0,0,-0.707f,0.707f);
    }

    public void Up()
    {
        walk = true;
        transform.rotation = new Quaternion(0, 0, 0, 1);
    }

    public void Down()
    {
        walk = true;
        transform.rotation = new Quaternion(0, 0, 1, 0);
    }

    public void OnRelease()
    {
        walk = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            againstDoor = true;
            doorText.SetActive(true);
            if (door)
            {
                other.gameObject.GetComponent<Door>().Destroy();
                door = false;
                doorText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            againstDoor = false;
            doorText.SetActive(false);
        }
    }

    public void IsPressed()
    {
        if (againstDoor)
        {
            door = true;
        }
    }
}