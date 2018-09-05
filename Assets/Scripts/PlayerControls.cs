using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public bool walk;

    public float playerSpeed;
    
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
        Debug.Log("stop");
        walk = false;
    }
}
