using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public bool walk;
    public GameObject doorText;
    public bool door;
    public bool againstDoor;

    public float playerSpeed;

    [Header(" ")]
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        doorText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (walk)
        {
            anim.SetInteger("State", 1);
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
        anim.SetInteger("State", 0);
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